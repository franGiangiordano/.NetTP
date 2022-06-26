using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


//Este formulario fue hecho para un laboratorio pero sirve también para el TP2


namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        /* este metodo debe ser reemplazado por un método que solicite a la capa de negocio recupere el        
           usuario con nombre igual al ingresado en el txtUsuario y si existe invocar a un método que 
           valide si su contraseña coincide con la ingresada en txtPass*/
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtPass.Text))
            {
                Notificar("Login", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {

                //otra alternativa para validar y retornar el usuario del login usando @Query a la BD

                UsuarioLogic ul = new UsuarioLogic();
                Usuario usuarioEncontrado = ul.GetUsuarioLogin(txtUsuario.Text, txtPass.Text);
                if (usuarioEncontrado.NombreUsuario != null)
                {
                    //Principal formPrincipal = new Principal();
                    //formPrincipal.ShowDialog();

                    PersonaLogic pl = new PersonaLogic();
                    Business.Entities.Persona personaEncontrada = pl.GetOne(usuarioEncontrado.IDPersona);
                    switch (personaEncontrada.Tipo)
                    {
                        case Business.Entities.Persona.TipoPersonas.Administrativo:
                            //aca hay que colocar la ventana correspondiente a cada tipo de usuario, estas son de prueba con las que ya existen
                            Principal formPrincipal = new Principal();
                            formPrincipal.ShowDialog();
                            break;

                        case Business.Entities.Persona.TipoPersonas.Alumno:
                            //aca hay que colocar la ventana correspondiente a cada tipo de usuario, estas son de prueba con las que ya existen
                            Personas Personas = new Personas();
                            Personas.ShowDialog();
                            break;

                        case Business.Entities.Persona.TipoPersonas.Docente:
                            //aca hay que colocar la ventana correspondiente a cada tipo de usuario, estas son de prueba con las que ya existen
                            Usuarios usuarios = new Usuarios();
                            usuarios.ShowDialog();
                            break;
                    }
                }
                else
                {
                    Notificar("Login", "Usuario y/o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                ////otra alternativa para validar y retornar el usuario del login usando linq

                //List<Usuario> usuarios = Listar();
                //List<Usuario> usuario = (from usu in usuarios where usu.NombreUsuario == txtUsuario.Text && usu.Clave == txtPass.Text select usu).ToList();
                ////la propiedad Text de los TextBox contiene el texto escrito en ellos
                //if (usuario.Any())
                //{
                //    Principal formPrincipal = new Principal();
                //    formPrincipal.ShowDialog();
                //}
                //else
                //{
                //    Notificar("Login", "Usuario y/o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

           private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        private void formLogin_Load(object sender, EventArgs e)
        {

        }

        public List<Usuario> Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            return ul.GetAll();
        }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

    }
}
