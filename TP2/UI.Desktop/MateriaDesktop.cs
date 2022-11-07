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

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Business.Entities.Materia materiaActual;

        public Materia MateriaActual { get => materiaActual; set => materiaActual = value; }

        public MateriaDesktop() {
            PlanLogic pl = new PlanLogic();
            InitializeComponent();
            //this.cmbPlan.DataSource = (from plan in pl.GetAll() select plan.Descripcion).ToList();
            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.DisplayMember = "Descripcion";
            this.cmbPlan.ValueMember = "ID";
        }

        public MateriaDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            //InitializeComponent();
        }
        public MateriaDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            //InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

       
        
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos() 
        {
            PlanLogic pl = new PlanLogic();

            this.txtId.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();

            //Esta linea sirve para obtener el indice de un Plan            
            //this.cmbPlan.SelectedIndex = this.cmbPlan.FindString((from plan in pl.GetAll() where plan.ID == this._MateriaActual.IDPlan select plan.Descripcion).ToList()[0]);
            this.cmbPlan.SelectedValue = this.MateriaActual.IDPlan;


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
            PlanLogic pl = new PlanLogic();
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Materia mat = new Materia();
                    MateriaActual = mat;
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = Int32.Parse(txtHsSemanales.Text);
                    MateriaActual.HSTotales = Int32.Parse(txtHsTotales.Text);

                    //En esta linea hacemos un mapeo entre el comboBox y el Plan
                    //MateriaActual.IDPlan =  (from plan in pl.GetAll() where cmbPlan.SelectedItem.ToString() == plan.Descripcion select plan.ID).ToList()[0];
                    MateriaActual.IDPlan = (int)cmbPlan.SelectedValue;

                    MateriaActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = Int32.Parse(txtHsSemanales.Text);
                    MateriaActual.HSTotales = Int32.Parse(txtHsTotales.Text);
                    MateriaActual.IDPlan = (int)cmbPlan.SelectedValue;
                    MateriaActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    MateriaActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    MateriaActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios() 
        {
            
            try {
                MapearADatos();
                MateriaLogic ml = new MateriaLogic();
                ml.Save(MateriaActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                this.Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override bool Validar()
        {
            MateriaLogic ml = new MateriaLogic();
            int n;
            string errores = "";
            if (String.IsNullOrEmpty(this.txtDescripcion.Text)
            || String.IsNullOrEmpty(this.txtHsSemanales.Text) || String.IsNullOrEmpty(this.txtHsTotales.Text)
            || String.IsNullOrEmpty(this.cmbPlan.Text) 
             )
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }

            
             if (!ml.validarEntero(txtHsSemanales.Text) || !ml.validarEntero(txtHsSemanales.Text))
              {
                errores += "Las horas tienen que ser numeros enteros\n";
             }
             else {
                if (Int32.Parse(txtHsSemanales.Text) < 0 || Int32.Parse(txtHsTotales.Text) < 0)
                {
                    errores += "Las horas deben ser mayores a 0\n";
                }
                else {
                    errores += ml.ValidarHs(this.txtHsSemanales.Text, this.txtHsTotales.Text);
                }
             }

            if (!Modo.ToString().Equals("Baja")  && ml.GetMateria(this.txtDescripcion.Text, (int)this.cmbPlan.SelectedValue) && (this.txtDescripcion.Text != materiaActual.Descripcion || (int)this.cmbPlan.SelectedValue != this.materiaActual.IDPlan))
            {
                errores += "Ya existe una materia con esas caracteristicas\n";
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


        //este metodo no se usa
        private void label1_Click(object sender, EventArgs e)
        {

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

        private void tlMaterias_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
