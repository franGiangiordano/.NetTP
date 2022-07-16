
﻿using System;
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
        public event EventHandler SelectedIndexChanged;

        public Persona DocenteActual { get => _docenteActual; set => _docenteActual = value; }

        public DocenteDesktop()
        {
            InitializeComponent();            
            cargarComboDocentes();

        }

        private void cargarComboDocentes()
        {
          PersonaLogic pl = new PersonaLogic();
          List<Persona> docentes = pl.GetLegajosDocentes();
          this.cmbDocente1.DataSource = docentes;
          this.cmbDocente1.DisplayMember = "Legajo";
          this.cmbDocente1.ValueMember = "ID";
          this.cmbDocente1.SelectedIndexChanged += new System.EventHandler(cmbDocente1_SelectedIndexChanged);

          this.cmbDocente2.DataSource = docentes.Where(x => x.ID != (int)this.cmbDocente1.SelectedValue).ToList(); ;
          this.cmbDocente2.DisplayMember = "Legajo";
          this.cmbDocente2.ValueMember = "ID";
          this.cmbDocente2.SelectedIndexChanged += new System.EventHandler(cmbDocente2_SelectedIndexChanged);

          Persona docente = pl.GetOne((int)this.cmbDocente1.SelectedValue);
          this.lblNomApe1.Text = "" + docente.Nombre + " " + docente.Apellido;

          Persona docente2 = pl.GetOne((int)this.cmbDocente2.SelectedValue);
          this.lblNomApe2.Text = "" + docente2.Nombre + " " + docente2.Apellido;

        }

        private void cmbDocente1_SelectedIndexChanged(object sender, EventArgs e)
        {            
                if (this.cmbDocente1.SelectedValue.ToString() != null)
                {                    
                    int idSeleccionado = (int)this.cmbDocente1.SelectedValue;                                        
                    PersonaLogic pl = new PersonaLogic();
                    Persona docente = pl.GetOne((int)this.cmbDocente1.SelectedValue);
                    this.lblNomApe1.Text = "" + docente.Nombre + " " + docente.Apellido;

                    List<Persona> docentes = pl.GetLegajosDocentes();
                    this.cmbDocente2.DataSource = docentes.Where(x => x.ID != (int)this.cmbDocente1.SelectedValue).ToList(); ;
                    this.cmbDocente2.DisplayMember = "Legajo";
                    this.cmbDocente2.ValueMember = "ID";

            }
        }


        private void cmbDocente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocente1.SelectedValue.ToString() != null)
            {
                int idSeleccionado = (int)this.cmbDocente2.SelectedValue;
                PersonaLogic pl = new PersonaLogic();
                Persona docente = pl.GetOne((int)this.cmbDocente2.SelectedValue);
                this.lblNomApe2.Text = "" + docente.Nombre + " " + docente.Apellido;                              
            }
        }


        public bool Validar() {
            string errores = "";
            if ((cmbCargo1.SelectedIndex == -1) || (cmbCargo2.SelectedIndex == -1))
            {
                errores += "Existen uno o mas campos vacios, rellenelos antes de continuar\n";
            }
            if ((cmbCargo1.SelectedIndex == 0) && (cmbCargo2.SelectedIndex == 0)) {

                errores += "No se pueden asignar dos ayudantes a un cuso sin al menos un Docente\n";
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
    }
}