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
        public Business.Entities.Materia _MateriaActual;
        public MateriaDesktop()
        {
            PlanLogic pl = new PlanLogic();
            InitializeComponent();            
            this.cmbPlan.DataSource = (from plan in pl.GetAll() select plan.Descripcion).ToList();
            this.cmbPlan.SelectedIndex = 1;
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
            _MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public enum ModoForm { Alta, Baja, Modificacion, Consulta };

        
        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }

        public virtual void MapearDeDatos() 
        {
            this.txtId.Text = this._MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this._MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this._MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this._MateriaActual.HSTotales.ToString();
            this.cmbPlan.SelectedIndex = this._MateriaActual.IDPlan;

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

        public virtual void MapearADatos() 
        {
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    Materia mat = new Materia();
                    _MateriaActual = mat;
                    _MateriaActual.Descripcion = txtDescripcion.Text;
                    _MateriaActual.HSSemanales = Int32.Parse(txtHsSemanales.Text);
                    _MateriaActual.HSTotales = Int32.Parse(txtHsTotales.Text);
                    _MateriaActual.IDPlan = cmbPlan.SelectedIndex;
                  
                    _MateriaActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    _MateriaActual.Descripcion = txtDescripcion.Text;
                    _MateriaActual.HSSemanales = Int32.Parse(txtHsSemanales.Text);
                    _MateriaActual.HSTotales = Int32.Parse(txtHsTotales.Text);
                    if (cmbPlan.Text.Equals("1996"))
                    {
                        _MateriaActual.IDPlan = 0;
                    }
                    else if (cmbPlan.Text.Equals("2008"))
                    {
                        _MateriaActual.IDPlan = 1;
                    }
                    _MateriaActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    _MateriaActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    _MateriaActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public virtual void GuardarCambios() 
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(_MateriaActual);
        }
        public virtual bool Validar()
        {
            if (String.IsNullOrEmpty(this.txtDescripcion.Text)
            || String.IsNullOrEmpty(this.txtHsSemanales.Text) || String.IsNullOrEmpty(this.txtHsTotales.Text)
            || String.IsNullOrEmpty(this.cmbPlan.Text) 
             )
            {
                this.Notificar("Campos Obligatorios Vacios", "Existen uno o mas campos vacios, rellenelos antes de continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (Int32.Parse(txtHsSemanales.Text) < 0)
            {
                this.Notificar("HsSemanales Invalida", "Las horas semanales deben ser mayores a 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (Int32.Parse(txtHsTotales.Text) < 0)
            {
                this.Notificar("HsTotales Invalida", "Las horas totales deben ser mayores a 0", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (Int32.Parse(txtHsSemanales.Text) > Int32.Parse(txtHsTotales.Text))
            {
                this.Notificar("Cantidad invalida", "La cantidad de hs Totales debe ser superior a las semanales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }

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
    }
}
