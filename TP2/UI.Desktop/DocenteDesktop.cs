
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

        public Persona DocenteActual { get => _docenteActual; set => _docenteActual = value; }

        public DocenteDesktop()
        {
            InitializeComponent();
            cargarComboDocentes1();

        }




        private void cargarComboDocentes1()
        {
          PersonaLogic pl = new PersonaLogic();
          List<Persona> docentes = pl.GetLegajosDocentes();
          this.cmbDocente1.DataSource = docentes;
          this.cmbDocente1.DisplayMember = "Legajo";
          this.cmbDocente1.ValueMember = "ID";
            this.cmbDocente1.SelectedIndexChanged += new System.EventHandler(cmbDocente1_SelectedIndexChanged); //asociamos el evento al combo   
            //esto es para que muestre nombre y apellido del docente sin tocar el combobox
            //int idSeleccionado = (int)this.cmbDocente1.SelectedValue;
            Persona docente = pl.GetOne((int)this.cmbDocente1.SelectedValue);
            this.lblNomApe1.Text = "" + docente.Nombre + " " + docente.Apellido;

        }

        private void cargarComboDocentes2()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = pl.GetLegajosDocentes();
            this.cmbDocente2.DataSource = docentes;
            this.cmbDocente2.DisplayMember = "Legajo";
            this.cmbDocente2.ValueMember = "ID";
            this.cmbDocente2.SelectedIndexChanged += new System.EventHandler(cmbDocente2_SelectedIndexChanged); //asociamos el evento al combo
        }


        private void cmbDocente1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocente1.SelectedValue.ToString() != null)
            {
                //int idSeleccionado = (int)this.cmbDocente1.SelectedValue;
                PersonaLogic pl = new PersonaLogic();
                Persona docente = pl.GetOne((int)this.cmbDocente1.SelectedValue);
                this.lblNomApe1.Text = "" + docente.Nombre + " " + docente.Apellido;
                //cargarComboDocentes2();

            }

        }

        private void cmbDocente2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDocente2.SelectedValue.ToString() != null)
            {
                //int idSeleccionado = (int)this.cmbDocente2.SelectedValue;
                PersonaLogic pl = new PersonaLogic();
                Persona docente = pl.GetOne((int)this.cmbDocente2.SelectedValue);
                this.lblNomApe2.Text = "" + docente.Nombre + " " + docente.Apellido;
            }
        }
    }
}