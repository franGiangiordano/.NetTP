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
        private Business.Entities.Persona _PersonaActual; //agregar propiedad

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        public PersonaDesktop()
        {
            PlanLogic pl = new PlanLogic();            
            InitializeComponent();
            iniciarCheckBox();
            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.DisplayMember = "Descripcion";
            this.cmbPlan.ValueMember = "ID";
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
            iniciarCheckBox();
            Modo = (ApplicationForm.ModoForm)modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            MapearDeDatos();
        }


        public void iniciarCheckBox() {
            this.checkAdmin.CheckedChanged += checkAdmin_CheckedChanged;
        }

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {            
        }

        public override void MapearDeDatos() {
           
            PlanLogic pl = new PlanLogic();

            this.txtId.Text = this.PersonaActual.ID.ToString();            
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApe.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDirec.Text = this.PersonaActual.Direccion;            
            this.txtTel.Text = this.PersonaActual.Telefono.ToString();
            this.txtLeg.Text = this.PersonaActual.Legajo.ToString();

            //Esta linea sirve para obtener el indice de un Plan            
            this.cmbPlan.SelectedValue = this.PersonaActual.IDPlan; 
            this.txtFechaNac.Text = this.PersonaActual.FechaNacimiento.ToString(); //ver como formatear
            this.cmbTipo.Text = this.PersonaActual.Tipo.ToString();

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
            PlanLogic pl = new PlanLogic();
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Persona per = new Persona();
                    PersonaActual = per;
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.Apellido = txtApe.Text;
                    PersonaActual.Direccion = txtDirec.Text;
                    PersonaActual.Telefono = txtTel.Text;
                    PersonaActual.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US"));


                    if (this.checkAdmin.Checked)
                    {
                        PersonaActual.Legajo = 1;
                        PersonaActual.IDPlan = 2;
                        PersonaActual.Tipo = Persona.TipoPersonas.Administrativo;
                    }
                    else {
                        PersonaActual.Legajo = Int32.Parse(txtLeg.Text);
                        PersonaActual.IDPlan = (int)cmbPlan.SelectedValue;
                        PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipo.SelectedItem.ToString());
                    }
                    
                    //PersonaActual.IDPlan = (from plan in pl.GetAll() where cmbPlan.SelectedItem.ToString() == plan.Descripcion select plan.ID).ToList()[0];                    

                    
                    
                    PersonaActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.Apellido = txtApe.Text;
                    PersonaActual.Direccion = txtDirec.Text;
                    PersonaActual.Telefono = txtTel.Text;
                    PersonaActual.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "dd/MM/yyyy", null);                                                          
                    if (this.checkAdmin.Checked)
                    {
                        PersonaActual.Legajo = 1;
                        PersonaActual.IDPlan = 2;
                        PersonaActual.Tipo = Persona.TipoPersonas.Administrativo;
                    }
                    else
                    {
                        PersonaActual.Legajo = Int32.Parse(txtLeg.Text);
                        PersonaActual.IDPlan = (int)cmbPlan.SelectedValue;
                        PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipo.SelectedItem.ToString());
                    }
                    PersonaActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    PersonaActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    PersonaActual.State = Usuario.States.Modified;
                    break;
            }

        }
        public override void GuardarCambios() {
            try
            {
                MapearADatos();
                PersonaLogic pl = new PersonaLogic();
                pl.Save(PersonaActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            

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
            || (!this.txtFechaNac.MaskFull) || String.IsNullOrEmpty(this.cmbPlan.Text)
            || String.IsNullOrEmpty(this.cmbTipo.Text)
             )                
                {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
                if (this.txtLeg.Enabled)
                {
                    if (String.IsNullOrEmpty(this.txtLeg.Text))
                    {
                        errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
                    }
                }

                //this.Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show(this.txtFechaNac.MaskFull.ToString());              
            }            
            if (!String.IsNullOrEmpty(this.txtEmail.Text) && (pl.IsValidMailAddress1(txtEmail.Text) == false))
            {
                 errores += "El Email ingresado es invalido\n";
                if (!errores.Equals(""))
                {
                    //this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                //this.Notificar("Mail Invalido", "El Email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
            }
            if (!int.TryParse(this.txtTel.Text, out n) && !String.IsNullOrEmpty(this.txtTel.Text))
            {
                errores += "El campo telefono solo puede contener numeros\n";
            }
            if (this.txtLeg.Enabled) {
                if (!int.TryParse(this.txtLeg.Text, out n))
                {
                    errores += "El campo legajo solo puede contener numeros\n";
                }
            }
            
            if (!String.IsNullOrEmpty(this.txtTel.Text)) {
                errores += pl.validaNum(Int32.Parse(this.txtTel.Text));
            }

            if (this.txtLeg.Enabled) {
                errores += pl.validaLeg(Int32.Parse(this.txtLeg.Text));
            }
            

            if (!this.txtNombre.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
            }
            if (!this.txtApe.Text.All(Char.IsLetter))
            {
                errores += "El campo apellido solo puede contener letras\n";
            }
            if (this.txtLeg.Enabled) {
                if (!Modo.ToString().Equals("Baja") && !this.txtLeg.Text.Equals("1") && pl.GetPersona(Int32.Parse(this.txtLeg.Text)))
                {
                    errores += "Ya existe una persona con ese legajo\n";
                }
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

        protected void checkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
                if (this.checkAdmin.Checked)
                {
                    this.cmbTipo.Enabled = false;
                    this.cmbPlan.Enabled = false;
                    this.txtLeg.Enabled = false;
                }
                else
                {
                    this.cmbTipo.Enabled = true;
                    this.cmbPlan.Enabled = true;
                    this.txtLeg.Enabled = true;
                }
                        
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
