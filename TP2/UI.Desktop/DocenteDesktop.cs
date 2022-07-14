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
    public partial class DocenteDesktop : ApplicationForm
    {
        private Business.Entities.Persona _docenteActual;

        public Persona DocenteActual { get => _docenteActual; set => _docenteActual = value; }

        public DocenteDesktop()
        {
            InitializeComponent();
            cargarComboDocentes();
        }



 
        private void cargarComboDocentes()
        {
            foreach (ComboBox cmb in Controls.OfType<ComboBox>().Where(x => x.Name.Contains("cmbDocente")).Reverse())
            {
                PersonaLogic pl = new PersonaLogic();
                List<Persona> docentes = pl.GetLegajosDocentes();
                cmb.DataSource = docentes;
                cmb.DisplayMember = "Legajo";
                cmb.ValueMember = "ID";
                cargaLabels((int)cmb.SelectedValue, cmb);
            }
        }

        private void cargaLabels(int idSeleccionado, ComboBox cmb)
        {
           PersonaLogic pl = new PersonaLogic();
           Persona docente = pl.GetOne(idSeleccionado);
           if(cmb.Name == "cmbDocente")
            {
                this.lblNomApe1.Text = "" + docente.Nombre + " " + docente.Apellido;
            }
            if (cmb.Name == "cmbDocente2")
            {
                this.lblNomApe2.Text = "" + docente.Nombre + " " + docente.Apellido;
            }

        }

        private void cmbDocente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocente.SelectedValue.ToString() != null)
            {
                int idSeleccionado = (int)this.cmbDocente.SelectedValue;
                cargaLabels(idSeleccionado, cmbDocente);
            }
        }

        private void cmbDocente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocente2.SelectedValue.ToString() != null)
            {
                int idSeleccionado = (int)this.cmbDocente2.SelectedValue;
                cargaLabels(idSeleccionado, cmbDocente2);
            }
        }
    }
}
