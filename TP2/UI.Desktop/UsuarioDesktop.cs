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

        private Business.Entities.Usuario usuarioActual;

        public Usuario UsuarioActual { get => usuarioActual; set => usuarioActual = value; }

        public UsuarioDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            InitializeComponent();
            //cargarComboLegajos();
        }
        public UsuarioDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            InitializeComponent();
            //cargarComboLegajos();
            Modo = (ApplicationForm.ModoForm)modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();            
        }

        //private void cargarComboLegajos()
        //{
        //    PersonaLogic pl = new PersonaLogic();            
        //    List<String> legajos = (from persona in pl.GetAll() select persona.Legajo.ToString()).ToList();
        //    this.cmbLegajos.DataSource = legajos.OrderBy(x => x).ToList();
        //}

        //public UsuarioDesktop(ApplicationForm.ModoForm alta)
        //{
        //    InitializeComponent();
        //}

        public UsuarioDesktop()
        {
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            PersonaLogic pl = new PersonaLogic();

            this.txtId.Text = this.UsuarioActual.ID.ToString();
            this.checkHab.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApe.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsu.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirm.Text = this.UsuarioActual.Clave;
            //this.cmbLegajos.SelectedIndex =this.cmbLegajos.FindString(pl.GetOne(this.UsuarioActual.IDPersona).Legajo.ToString());            
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
            PersonaLogic pl = new PersonaLogic();

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Usuario usu = new Usuario();
                    UsuarioActual = usu;
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = checkHab.Checked;
                    UsuarioActual.Apellido = txtApe.Text;
                    UsuarioActual.NombreUsuario = txtUsu.Text;                    
                    //_UsuarioActual.IDPersona = (pl.GetOnePorLejago(Int32.Parse(cmbLegajos.SelectedItem.ToString()))).ID;                    
                    UsuarioActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    UsuarioActual.Nombre = txtNombre.Text;
                    UsuarioActual.Email = txtEmail.Text;
                    UsuarioActual.Clave = txtClave.Text;
                    UsuarioActual.Habilitado = checkHab.Checked;
                    UsuarioActual.Apellido = txtApe.Text;
                    UsuarioActual.NombreUsuario = txtUsu.Text;
                    //_UsuarioActual.IDPersona = (pl.GetOnePorLejago(Int32.Parse(cmbLegajos.SelectedItem.ToString()))).ID;
                    UsuarioActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    UsuarioActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    UsuarioActual.State = Usuario.States.Modified;
                    break;
            }
        }
        
        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            string errores = "";
            UsuarioLogic ul = new UsuarioLogic();
            if ( String.IsNullOrEmpty(this.txtNombre.Text)
            || String.IsNullOrEmpty(this.txtApe.Text) || String.IsNullOrEmpty(this.txtClave.Text)
            || String.IsNullOrEmpty(this.txtConfirm.Text) || String.IsNullOrEmpty(this.txtUsu.Text)
             )
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            errores += ul.validarLongitud(txtClave.Text);
            errores += ul.validarClave(txtClave.Text, txtConfirm.Text);
            
            if (ul.IsValidMailAddress1(txtEmail.Text) == false)
            {
                errores += "El Email ingresado es invalido\n";               
            }
            if (!this.txtNombre.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
            }
            if (!this.txtApe.Text.All(Char.IsLetter))
            {
                errores += "El campo apellido solo puede contener letras\n";
            }
            if (!errores.Equals(""))
            {
                this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
        /*
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
        }*/



        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
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
