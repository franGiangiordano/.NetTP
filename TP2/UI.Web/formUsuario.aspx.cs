using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class formUsuario : System.Web.UI.Page
    {
        private Business.Entities.Usuario usuarioActual;

        public Usuario UsuarioActual { get => usuarioActual; set => usuarioActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {

           //GridViewRow a = (GridViewRow)Session["celda"];
           //int id = Int32.Parse(a.Cells[0].Text.ToString());
            cargarComboLegajos();

        }

        private void cargarComboLegajos()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> legajos = pl.GetLegajos();
            this.cmbLegajos.DataSource = legajos;
            this.cmbLegajos.DataTextField = "Legajo";
            this.cmbLegajos.DataValueField = "ID";
            this.cmbLegajos.DataBind();
        }

        public void MapearADatos()
        {
            String Modo = Request.QueryString["modo"];

            PersonaLogic pl = new PersonaLogic();

            switch (Modo)
            {
                case "alta":
                    Usuario usu = new Usuario();
                    UsuarioActual = usu;
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = chkHabilitado.Checked;
                    UsuarioActual.Apellido = txtApellido.Text;
                    UsuarioActual.NombreUsuario = txtUsuario.Text;
                    UsuarioActual.IdPersona = Int32.Parse(this.cmbLegajos.SelectedValue);
                    UsuarioActual.State = Usuario.States.New;
                    break;

                //case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                //    UsuarioActual.Nombre = txtNombre.Text;
                //    UsuarioActual.Email = txtEmail.Text;
                //    if (!txtClave.Text.Equals(UsuarioActual.Clave))
                //    {
                //        UsuarioActual.CambiaClave = true;
                //        UsuarioActual.Clave = txtClave.Text;
                //    }
                //    else
                //    {
                //        UsuarioActual.CambiaClave = false;
                //    }

                //    UsuarioActual.Habilitado = checkHab.Checked;
                //    UsuarioActual.Apellido = txtApe.Text;
                //    UsuarioActual.NombreUsuario = txtUsu.Text;
                //    //_UsuarioActual.IDPersona = (pl.GetOnePorLejago(Int32.Parse(cmbLegajos.SelectedItem.ToString()))).ID;
                //    UsuarioActual.IdPersona = (int)this.cmbLegajos.SelectedValue;
                //    UsuarioActual.State = Usuario.States.Modified;
                //    break;

                //case (ApplicationForm.ModoForm)ModoForm.Baja:
                //    UsuarioActual.State = Usuario.States.Deleted;
                //    break;

                //case (ApplicationForm.ModoForm)ModoForm.Consulta:
                //    UsuarioActual.State = Usuario.States.Modified;
                //    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                //esto es sólo en caso de que se modifique el id_persona y cambie el rol del usuario
                //int idViejo = -1;
                //if (Modo.ToString().Equals("Modificacion"))
                //{
                //    idViejo = this.UsuarioActual.IdPersona;
                //}

                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                PersonaLogic pl = new PersonaLogic();
                UsuarioLogic ul = new UsuarioLogic();
                MapearADatos(); //aca ya cambio el Id

                String Modo = Request.QueryString["modo"];
                if (Modo.Equals("alta"))
                {
                    ul.Save(UsuarioActual);
                    Persona per = pl.GetOne(UsuarioActual.IdPersona);
                    List<ModuloUsuario> modulos = crearLista((int)per.Tipo);
                    try
                    {
                        mul.CargarPermisos(modulos);
                    }
                    catch (Exception Ex)
                    {
                        Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                        Response.Write("<script>alert("+ ExcepcionManejada.Message+");</script>");

                    }
                }
                //else if (Modo.ToString().Equals("Baja"))
                //{
                //    try
                //    {
                //        mul.EliminarPermisos(UsuarioActual.ID);
                //        ul.Save(UsuarioActual);
                //    }
                //    catch (Exception Ex)
                //    {
                //        Exception ExcepcionManejada = new Exception("Error al eliminar permisos", Ex);
                //        this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //}
                //else if (Modo.ToString().Equals("Modificacion"))
                //{
                //    Persona perNueva = pl.GetOne(UsuarioActual.IdPersona);
                //    Persona perVieja = pl.GetOne(idViejo);
                //    if (perNueva.Tipo == perVieja.Tipo)
                //    {
                //        ul.Save(UsuarioActual);
                //    }
                //    else
                //    {
                //        try
                //        {
                //            mul.EliminarPermisos(UsuarioActual.ID);
                //            List<ModuloUsuario> modulos = crearLista((int)perNueva.Tipo);
                //            mul.CargarPermisos(modulos);
                //            ul.Save(UsuarioActual);
                //        }
                //        catch (Exception Ex)
                //        {
                //            Exception ExcepcionManejada = new Exception("Error al cargar permisos", Ex);
                //            this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //        }

                //    }
                //}
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");

            }

        }

        private List<ModuloUsuario> crearLista(int tipo)
        {
            List<ModuloUsuario> m = new List<ModuloUsuario>();
            for (int i = 1; i <= 7; i++)
            {
                ModuloUsuario modulo = new ModuloUsuario();
                if (tipo == 2)
                {
                    modulo.IdModulo = i;
                    modulo.IdUsuario = UsuarioActual.ID;
                    modulo.PermiteAlta = true;
                    modulo.PermiteBaja = true;
                    modulo.PermiteConsulta = true;
                    modulo.PermiteModificacion = true;
                }
                else if (tipo == 0)
                {
                    if (i == 1)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else if (i >= 5)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = true;
                        modulo.PermiteBaja = true;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = false;
                        modulo.PermiteModificacion = false;
                    }
                }
                else if (tipo == 1)
                {
                    if (i == 1 || i == 5 || i == 6)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = true;
                    }
                    else if (i == 7)
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = true;
                        modulo.PermiteModificacion = false;
                    }
                    else
                    {
                        modulo.IdModulo = i;
                        modulo.IdUsuario = UsuarioActual.ID;
                        modulo.PermiteAlta = false;
                        modulo.PermiteBaja = false;
                        modulo.PermiteConsulta = false;
                        modulo.PermiteModificacion = false;
                    }
                }
                m.Add(modulo);
            }
            return m;
        }

        public bool Validar()
        {
            String Modo = Request.QueryString["modo"];
            string errores = "";
            UsuarioLogic ul = new UsuarioLogic();
            if (String.IsNullOrEmpty(this.txtNombre.Text)
            || String.IsNullOrEmpty(this.txtApellido.Text) || String.IsNullOrEmpty(this.txtClave.Text)
            || String.IsNullOrEmpty(this.txtConfirmarClave.Text) || String.IsNullOrEmpty(this.txtUsuario.Text)
             )
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            errores += ul.validarLongitud(txtClave.Text);
            errores += ul.validarClave(txtClave.Text, txtConfirmarClave.Text);

            if (ul.IsValidMailAddress1(txtEmail.Text) == false)
            {
                errores += "El Email ingresado es invalido\n";
            }
            if (!this.txtNombre.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
            }
            if (!this.txtApellido.Text.All(Char.IsLetter))
            {
                errores += "El campo apellido solo puede contener letras\n";
            }
            if (!Modo.Equals("Baja") && ul.GetUser(txtUsuario.Text) && usuarioActual.NombreUsuario != this.txtUsuario.Text)
            {
                errores += "Ya existe un usuario con ese nombre de usuario\n";
            }

            if (!errores.Equals(""))
            {
                Response.Write($"<script>alert('{errores}');</script>");//esto es para mostrar una alerta de los errores
                return false;
            }
            else
            {
                return true;
            }
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    GuardarCambios();
                    Response.Write("<script>alert(Usuario añadido exitosamente);</script>");
                    Response.Redirect("~/Usuarios.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar usuarios", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }
    }
}