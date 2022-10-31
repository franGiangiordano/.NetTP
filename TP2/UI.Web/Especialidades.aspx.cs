using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            Response.Redirect("~/formEspecialidad.aspx");
        }

        protected void grdEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                string ide = grdEspecialidades.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "modificacion";
                Session["id"] = ide;
                Response.Redirect("~/formEspecialidad.aspx");
            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdEspecialidades.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);

                Especialidad esp = new Especialidad();
                esp.ID = id;
                esp.State = BusinessEntity.States.Deleted;
                try
                {
                    EspecialidadLogic el = new EspecialidadLogic();
                    el.Save(esp);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
            }
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
    }
}
