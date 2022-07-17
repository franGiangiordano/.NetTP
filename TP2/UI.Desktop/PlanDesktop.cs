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
    public partial class PlanDesktop : ApplicationForm
    {
        private Business.Entities.Plan planActual;          
        public Plan PlanActual { get => planActual; set => planActual = value; } 

        public PlanDesktop()
        {
            InitializeComponent();
            cargarComboEspecialidades();
        }

        public PlanDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
        }
        public PlanDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            PlanLogic el = new PlanLogic();
            PlanActual = el.GetOne(ID);
            MapearDeDatos();
        }

        private void cargarComboEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            List<Especialidad> especialidades = el.GetEspecialidades();
            this.cmbEspecialidades.DataSource = especialidades;
            this.cmbEspecialidades.DisplayMember = "Descripcion";
            this.cmbEspecialidades.ValueMember = "ID";
        }

        public override void MapearDeDatos()
        {

            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cmbEspecialidades.SelectedValue = this.PlanActual.IDEspecialidad;
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
                    Plan plan= new Plan();
                    PlanActual = plan;
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.IDEspecialidad = (int)this.cmbEspecialidades.SelectedValue;
                    PlanActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.IDEspecialidad = (int)this.cmbEspecialidades.SelectedValue;
                    PlanActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    PlanActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    PlanActual.State = Usuario.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic el = new PlanLogic();
            el.Save(PlanActual);
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        public override bool Validar()
        {
            string errores = "";
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            if (!this.txtDescripcion.Text.All(Char.IsLetter))
            {
                errores += "El campo nombre solo puede contener letras\n";
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
    }
}
