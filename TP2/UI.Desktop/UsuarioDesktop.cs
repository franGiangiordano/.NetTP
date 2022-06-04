using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;


namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {

        public Business.Entities.Usuario _UsuarioActual;
        public UsuarioDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            InitializeComponent();
        }
        public UsuarioDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            UsuarioLogic ul = new UsuarioLogic();
            _UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        //public UsuarioDesktop(ApplicationForm.ModoForm alta)
        //{
        //    InitializeComponent();
        //}

        public UsuarioDesktop()
        {
        }

        public enum ModoForm { Alta, Baja, Modificacion, Consulta };

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        public virtual void MapearDeDatos()
        {
            this.txtId.Text = this._UsuarioActual.ID.ToString();
            this.checkHab.Checked = this._UsuarioActual.Habilitado;
            this.txtNombre.Text = this._UsuarioActual.Nombre;
            this.txtApe.Text = this._UsuarioActual.Apellido;
            this.txtEmail.Text = this._UsuarioActual.Email;
            this.txtUsu.Text = this._UsuarioActual.NombreUsuario;
            this.txtClave.Text = this._UsuarioActual.Clave;
            this.txtConfirm.Text = this._UsuarioActual.Clave;

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

            }
        }


        public override void MapearADatos()
        {
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Usuario usu = new Usuario();
                    _UsuarioActual = usu;
                    _UsuarioActual.Nombre = txtNombre.Text;
                    _UsuarioActual.Email = txtEmail.Text;
                    _UsuarioActual.Clave = txtClave.Text;
                    _UsuarioActual.Habilitado = checkHab.Checked;
                    _UsuarioActual.Apellido = txtApe.Text;
                    _UsuarioActual.NombreUsuario = txtUsu.Text;
                    _UsuarioActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    _UsuarioActual.Nombre = txtNombre.Text;
                    _UsuarioActual.Email = txtEmail.Text;
                    _UsuarioActual.Clave = txtClave.Text;
                    _UsuarioActual.Habilitado = checkHab.Checked;
                    _UsuarioActual.Apellido = txtApe.Text;
                    _UsuarioActual.NombreUsuario = txtUsu.Text;
                    _UsuarioActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    _UsuarioActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    _UsuarioActual.State = Usuario.States.Modified;
                    break;
            }
        }
        //este es el que hicimos en el lab
        //public virtual void MapearADatos() {
        //    Business.Entities.Usuario usu = new Usuario();
        //    usu = _UsuarioActual;

        //    if (((ApplicationForm.ModoForm)ModoForm.Alta == Modo))
        //    {
        //        usu.Nombre = this.txtNombre.Text;
        //        usu.Apellido = this.txtApe.Text;
        //        usu.Email = this.txtEmail.Text;
        //        usu.NombreUsuario = this.txtUsu.Text;
        //        usu.Clave = this.txtClave.Text;
        //        usu.Habilitado = this.checkHab.Checked;
        //    } else if (((ApplicationForm.ModoForm)ModoForm.Modificacion == Modo)) {
        //        usu.ID = Int32.Parse(this.txtId.Text);
        //        usu.Nombre = this.txtNombre.Text;
        //        usu.Apellido = this.txtApe.Text;
        //        usu.Email = this.txtEmail.Text;
        //        usu.NombreUsuario = this.txtUsu.Text;
        //        usu.Clave = this.txtClave.Text;
        //        usu.Habilitado = this.checkHab.Checked;
        //    }

        //    _UsuarioActual.State = (BusinessEntity.States)Modo;
        //}
        public virtual void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(_UsuarioActual);
        }

        public virtual bool Validar()
        {
            if ( String.IsNullOrEmpty(this.txtNombre.Text)
            || String.IsNullOrEmpty(this.txtApe.Text) || String.IsNullOrEmpty(this.txtClave.Text)
            || String.IsNullOrEmpty(this.txtConfirm.Text) || String.IsNullOrEmpty(this.txtUsu.Text)
            || String.IsNullOrEmpty(this.txtEmail.Text)
             )
            {
                this.Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtClave.Text.Length < 8)
            {
                this.Notificar("Contraseña Invalida", "La contraseña debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtClave.Text != txtConfirm.Text)
            {
                this.Notificar("Confirmar Clave y clave no coinciden", "Los campos de clave no coinciden, verifiquelos e intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (ValidarMail(txtEmail.Text) == false)
            {
                this.Notificar("Mail Invalido", "El Email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }

        private bool ValidarMail(string Email)
        {
            bool arrobaFlag = false;
            bool dominioFlag = false;
            for (int i = 0; i < Email.Length; i++)
            {
                if (Email[i] == '@')
                {
                    arrobaFlag = true;
                    if (Email.Contains(".com") || Email.Contains(".net") || Email.Contains(".edu") || Email.Contains(".com.ar"))
                    {
                        dominioFlag = true;
                        break;
                    }
                    else
                        dominioFlag = false;
                }
                else
                    arrobaFlag = false;
            }
            if (arrobaFlag && dominioFlag)
                return true;
            else
                return false;
        }

        // este es el que hicimos en el lab
        //public virtual bool Validar()
        //{
        //    if (String.IsNullOrEmpty(this.txtId.Text) || String.IsNullOrEmpty(this.txtNombre.Text)
        //     || String.IsNullOrEmpty(this.txtApe.Text) || String.IsNullOrEmpty(this.txtClave.Text)
        //     || String.IsNullOrEmpty(this.txtConfirm.Text) || String.IsNullOrEmpty(this.txtUsu.Text)
        //     || String.IsNullOrEmpty(this.txtEmail.Text)
        //     )
        //    {
        //        MessageBox.Show("Uno o mas campos estan vacios", "Error"
        //        , MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    if (this.txtClave.Text.Equals(this.txtConfirm.Text))
        //    {
        //        MessageBox.Show("Las contraseñas no coinciden", "Error"
        //        , MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    if (this.txtClave.Text.Length < 8)
        //    {
        //        MessageBox.Show("La contraseña debe tener al menos 8 caracteres", "Error"
        //         , MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    //new System.Net.Mail.MailAddress(unMail); item 17
        //    // ATENCION! - ver si esta alternativa de mail esta ok 
        //    var addr = new System.Net.Mail.MailAddress(this.txtEmail.Text);
        //    if(addr.Address != this.txtEmail.Text)
        //    {
        //        return false;
        //    }

        //    return true;
        //}


        public void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
