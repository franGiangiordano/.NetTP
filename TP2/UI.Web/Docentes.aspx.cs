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
    public partial class Docentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarPermisos();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            //Session["idCurso"] = Session["id"]; //Session["id"] = curso
            Response.Redirect("~/formDocente.aspx");

        }

        protected void grdDocentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                string ide = grdDocentes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "modificacion";
                //Session["idCurso"] = Session["id"];
                Session["idDocenteCurso"] = ide;  
                Response.Redirect("~/formDocente.aspx");
            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdDocentes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);

                DocenteCurso docente = new DocenteCurso();
                docente.ID = id;
                docente.State = BusinessEntity.States.Deleted;
                try
                {
                    DocenteCursoLogic dcl = new DocenteCursoLogic();
                    dcl.Save(docente);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar Docente", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
            }
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("Docentes");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);

            if (!mu.PermiteAlta) //es Docente
            {
                this.grdDocentes.Columns[5].Visible = false;
                this.grdDocentes.Columns[6].Visible = false;
                this.btnInsertar.Visible = false;
            }

        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");
        }
    }
}