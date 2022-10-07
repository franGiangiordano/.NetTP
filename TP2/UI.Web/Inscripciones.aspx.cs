using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Inscripciones : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarNotas();



        }

        private void mostrarNotas()
        {
            foreach (GridViewRow row in grdInscripciones.Rows)
            {
                string nota = row.Cells[4].Text;
                if (nota.Equals("-1"))
                {
                    row.Cells[4].Text = "";
                }
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            Response.Redirect("~/formInscripcion.aspx");
        }

        protected void grdInscripciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                string ide = grdInscripciones.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "modificacion";
                Session["id"] = ide;
                Response.Redirect("~/formInscripcion.aspx");
            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdInscripciones.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);

                AlumnoInscripcion ai = new AlumnoInscripcion();
                ai.ID = id;
                ai.State = BusinessEntity.States.Deleted;
                try
                {
                    AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                    ail.Save(ai);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar inscripcion", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
            }
        }

    }
}