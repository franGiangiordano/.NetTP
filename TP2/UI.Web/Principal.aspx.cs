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
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validarPermisos();
        }

        //este metodo es para redireccionar enlaces, LinkButton es similar a <a> de HTML
        protected void LinkButtonUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

        protected void LinkButtonPersonas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personas.aspx");

        }

        protected void LinkButtonEspecialidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Especialidades.aspx");

        }
        protected void LinkButtonCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");

        }
        
        protected void LinkButtonMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");

        }

        protected void LinkButtonPlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Planes.aspx");

        }

        protected void LinkButtonComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");

        }

        protected void LinkButtonInscripciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inscripciones.aspx");

        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            ModuloUsuario mu = null;
            try
            {
                int idModulo = mul.GetIdModulo("Principal");
                mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
            }


            if (!mu.PermiteAlta && mu.PermiteModificacion)
            {

                //esto es para ocultar los botones que no corresponden a los permisos del usuario en cuestion
                this.LinkButtonPersonas.Visible = false;
                this.LinkButtonUsuarios.Visible = false;
                this.LinkButtonEspecialidades.Visible = false;
                this.LinkButtonMaterias.Visible = false;
                this.LinkButtonPlanes.Visible = false;
                this.LinkButtonComisiones.Visible = false;

                //this.txtRol.Text = "Docente"; //esto es para mostrar el rol del usuario Logueado
            }
            else if (!mu.PermiteAlta && !mu.PermiteModificacion)
            {
                this.LinkButton3.Visible = false;
                //this.txtRol.Text = "Alumno";
            }

            if (mu.PermiteAlta && mu.PermiteModificacion && mu.PermiteBaja)
            {

                //this.txtRol.Text = "Administrador"; //esto es para mostrar el rol del usuario Logueado
            }
        }

    }
}