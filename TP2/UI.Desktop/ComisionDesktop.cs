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
    public partial class ComisionDesktop : ApplicationForm
    {
        private Business.Entities.Comision comisionActual;

        public Comision ComisionActual { get => comisionActual; set => comisionActual = value; }

        public ComisionDesktop()
        {
            InitializeComponent();
            cargarComboPlanes();
        }

        public ComisionDesktop(ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
        }
        public ComisionDesktop(int ID, ApplicationForm.ModoForm modo) : this()
        {
            Modo = (ApplicationForm.ModoForm)modo;
            ComisionLogic pl = new ComisionLogic();
            ComisionActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        private void cargarComboPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = pl.GetDescripcionPlanes();
            this.cmbPlanes.DataSource = planes;
            this.cmbPlanes.DisplayMember = "Descripcion";
            this.cmbPlanes.ValueMember = "ID";
        }

        public override void MapearDeDatos()
        {
            this.txtDesc.Text = this.ComisionActual.Descripcion;
            this.txtAnioCalendario.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cmbPlanes.SelectedValue = this.ComisionActual.IDPlan;
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
                    Comision com = new Comision();
                    ComisionActual = com;
                    ComisionActual.Descripcion = txtDesc.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioCalendario.Text);
                    ComisionActual.IDPlan = (int)this.cmbPlanes.SelectedValue;
                    ComisionActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    ComisionActual.Descripcion = txtDesc.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnioCalendario.Text);
                    ComisionActual.IDPlan = (int)this.cmbPlanes.SelectedValue;
                    ComisionActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    ComisionActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    ComisionActual.State = Usuario.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
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
            int n;
            string errores = "";
            if (String.IsNullOrEmpty(this.txtDesc.Text))
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            if (!int.TryParse(this.txtAnioCalendario.Text, out n) )
            {
                errores += "El campo Año Calendario solo puede contener numeros\n";
            }
            else if (Int32.Parse(txtAnioCalendario.Text) < 2022)
            {
                errores += "El campo Año Calendario debe ser el año actual o posterior\n";
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
