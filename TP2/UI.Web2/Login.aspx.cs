using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
  
        protected void btnIngresar_Click(object sender, EventArgs e){
            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                Page.Response.Write("Existen uno o mas campos vacios, rellenelos antes de continuar");
            }
            else
            {

                //otra alternativa para validar y retornar el usuario del login usando @Query a la BD

                UsuarioLogic ul = new UsuarioLogic();
                Usuario usuarioEncontrado = null;
                try
                {
                    usuarioEncontrado = ul.GetUsuarioLogin(txtUsuario.Text, txtPassword.Text);
                }
                catch (Exception ex)
                {
                    Exception ExcepcionManejada = new Exception("Error en la conexión con la base de datos");
                    Page.Response.Write(ExcepcionManejada.Message);

                }


                if (usuarioEncontrado != null)
                {
                    if (usuarioEncontrado.Habilitado != false)
                    {
                        Session["usuario"] = usuarioEncontrado;
                        Response.Redirect("~/About.aspx");

                        //Response.Redirect("~/About.aspx?msj="+usuarioEncontrado.ID.ToString());
                        //Principal formPrincipal = new Principal(usuarioEncontrado.ID);
                        //this.Hide();
                        //formPrincipal.ShowDialog();
                       //formPrincipal.Show();
                       // formPrincipal.FormClosed += Logout;
                        //this.Show();
                       // this.Hide();
                    }
                    else
                    {
                        Page.Response.Write("Lo sentimos, no puede ingresar al sistema \n Su usuario se encuentra inhabilitado");
                    }

                }
                else
                {
                    Page.Response.Write("Usuario y/o contraseña incorrectos");
                }
            }
        }
    }
}