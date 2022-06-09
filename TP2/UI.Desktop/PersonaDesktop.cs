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
using System.Globalization;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public Business.Entities.Persona _PersonaActual;
      
        public PersonaDesktop()
        {
            PlanLogic pl = new PlanLogic();            
            InitializeComponent();
            this.cmbPlan.DataSource = (from plan in pl.GetAll() select plan.Descripcion).ToList() ;            
            this.cmbTipo.SelectedIndex = 1;
            
        }

        public PersonaDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            //InitializeComponent();            
        }

        
        public PersonaDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
          //  InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            PersonaLogic pl = new PersonaLogic();
            _PersonaActual = pl.GetOne(ID);
            MapearDeDatos();
        }


        private void PersonaDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos() {
            this.txtId.Text = this._PersonaActual.ID.ToString();            
            this.txtNombre.Text = this._PersonaActual.Nombre;
            this.txtApe.Text = this._PersonaActual.Apellido;
            this.txtEmail.Text = this._PersonaActual.Email;
            this.txtDirec.Text = this._PersonaActual.Direccion;            
            this.txtTel.Text = this._PersonaActual.Telefono;
            this.txtLeg.Text = this._PersonaActual.Legajo.ToString();
            this.cmbPlan.SelectedIndex = this._PersonaActual.IDPlan;            
            this.txtFechaNac.Text = this._PersonaActual.FechaNacimiento.ToString();
            this.cmbTipo.Text = this._PersonaActual.Tipo.ToString();

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
        public override void MapearADatos() {
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Persona per = new Persona();
                    _PersonaActual = per;
                    _PersonaActual.Nombre = txtNombre.Text;
                    _PersonaActual.Email = txtEmail.Text;
                    _PersonaActual.Apellido = txtApe.Text;
                    _PersonaActual.Direccion = txtDirec.Text;
                    _PersonaActual.Telefono = txtTel.Text;
                    _PersonaActual.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
                    _PersonaActual.IDPlan = cmbPlan.SelectedIndex;
                    
                    _PersonaActual.Legajo = Int32.Parse(txtLeg.Text);                    
                    _PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipo.SelectedItem.ToString());                    
                    _PersonaActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    _PersonaActual.Nombre = txtNombre.Text;
                    _PersonaActual.Email = txtEmail.Text;
                    _PersonaActual.Apellido = txtApe.Text;
                    _PersonaActual.Direccion = txtDirec.Text;
                    _PersonaActual.Telefono = txtTel.Text;
                    _PersonaActual.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "dd/MM/yyyy", null);
                    _PersonaActual.IDPlan = cmbPlan.SelectedIndex;
                    
                    _PersonaActual.Legajo = Int32.Parse(txtLeg.Text);
                    _PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipo.SelectedItem.ToString());
                    _PersonaActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    _PersonaActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    _PersonaActual.State = Usuario.States.Modified;
                    break;
            }

        }
        public override void GuardarCambios() {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(_PersonaActual);

        }        
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


        public override bool Validar()
        {
            int n;
            string errores = "";
            PersonaLogic pl = new PersonaLogic();
            if (String.IsNullOrEmpty(this.txtNombre.Text)
            || String.IsNullOrEmpty(this.txtApe.Text) || String.IsNullOrEmpty(this.txtDirec.Text)
            || (!this.txtFechaNac.MaskFull) || String.IsNullOrEmpty(this.txtTel.Text)
            || String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.cmbPlan.Text)
            || String.IsNullOrEmpty(this.txtLeg.Text) || String.IsNullOrEmpty(this.cmbTipo.Text)
             )
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
                //this.Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show(this.txtFechaNac.MaskFull.ToString());              
            }            
            if (pl.IsValidMailAddress1(txtEmail.Text) == false)
            {
                 errores += "El Email ingresado es invalido\n";
                if (!errores.Equals(""))
                {
                    //this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                //this.Notificar("Mail Invalido", "El Email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
            }
            if (!int.TryParse(this.txtTel.Text, out n))
            {
                errores += "El campo telefono solo puede contener numeros\n";
            }
            if (!int.TryParse(this.txtLeg.Text, out n))
            {
                errores += "El campo legajo solo puede contener numeros\n";
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
            }else
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
