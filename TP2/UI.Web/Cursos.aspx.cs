using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarPermisos();
        }
        protected void grdCursos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                string ide = grdCursos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "modificacion";
                Session["id"] = ide;
               Response.Redirect("~/formCurso.aspx");
            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdCursos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);

                Curso com = new Curso();
                com.ID = id;
                com.State = BusinessEntity.States.Deleted;
                try
                {
                    CursoLogic cl = new CursoLogic();
                    cl.Save(com);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
            }
            else if(e.CommandName == "Docentes")
            {
                string ide = grdCursos.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "docentes";
                Session["id"] = ide;
                Response.Redirect("~/Docentes.aspx");
            }
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("Docentes");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);

            if (!mu.PermiteAlta) //es Docente
            {
                this.grdCursos.Columns[5].Visible = false;
                this.grdCursos.Columns[6].Visible = false;
                this.btnInsertar.Visible = false;
            }

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            Response.Redirect("~/formCurso.aspx");
        }

        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
    }
}