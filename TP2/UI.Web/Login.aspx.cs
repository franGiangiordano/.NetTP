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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                Response.Write("<script>alert('Existen uno o mas campos vacios, rellenelos antes de continuar');</script>");
            }
            else
            {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario usuarioEncontrado = null;
                try
                {
                    usuarioEncontrado = ul.GetUsuarioLogin(txtUsuario.Text, txtPassword.Text);
                }
                catch (Exception ex)
                {
                    Exception ExcepcionManejada = new Exception("Error en la conexión con la base de datos");
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
                if (usuarioEncontrado != null)
                {
                    if (usuarioEncontrado.Habilitado != false)
                    {
                        Session["usuario"] = usuarioEncontrado;
                        Response.Redirect("~/Principal.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Lo sentimos, no puede ingresar al sistema \n Su usuario se encuentra inhabilitado');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Usuario y/o contraseña incorrectos');</script>");
                }
            }
        }
    }
}