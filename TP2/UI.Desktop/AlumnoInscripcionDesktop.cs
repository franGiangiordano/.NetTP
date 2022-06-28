﻿using System;
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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        public Business.Entities.AlumnoInscripcion _AlumnoInscripcionActual;
        // public event EventHandler SelectedIndexChanged; //evento para controlar cuando se elige una materia del combo

        int idAlumno;

        public AlumnoInscripcionDesktop(){
            InitializeComponent();            
        }

        public AlumnoInscripcionDesktop(int idPersona)
        {
            InitializeComponent();
            cargarComboMaterias(idPersona);
            cargarComboComisiones(idPersona);
            idAlumno = idPersona;

            //Bloqueamos el combo de condicion salvo que sea admin
            PersonaLogic pl = new PersonaLogic();
            if (!(((pl.GetOne(idAlumno)).Tipo.ToString()).Equals("Admin")))
            {
                this.cmbCondicion.Enabled = false;
            }

        }

        public AlumnoInscripcionDesktop(int idPersona, int ID, ApplicationForm.ModoForm modo) : this()
        {
           // InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;
            cargarComboMaterias(idPersona);
            cargarComboComisiones(idPersona);
            idAlumno = idPersona;
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            _AlumnoInscripcionActual = ail.GetOne(ID);
            MapearDeDatos();

        }



        public void cargarComboMaterias(int idPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            Persona personaActual = pl.GetOne(idPersona);

            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetMateriasPlan(personaActual.IDPlan);            
            this.cmbMateria.DataSource = (from mat in materias select mat.Descripcion).ToList();
           // this.cmbMateria.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged); //asociamos el evento al combo            
        }

        private void cargarComboComisiones(int idPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            Persona personaActual = pl.GetOne(idPersona);

            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = cl.GetComisionesPlan(personaActual.IDPlan);
            this.cmbComision.DataSource = (from com in comisiones select com.Descripcion).ToList();
            
        }

        public override void MapearDeDatos()
        {
            MateriaLogic ml = new MateriaLogic();            
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            PersonaLogic pl = new PersonaLogic();

            this.txtID.Text = this._AlumnoInscripcionActual.ID.ToString();

            //Esta linea sirve para obtener el indice de una Materia
            this.cmbMateria.SelectedIndex = this.cmbMateria.FindString(ml.GetOne((cl.GetOne(_AlumnoInscripcionActual.IDCurso).IDMateria)).Descripcion);
            this.cmbComision.SelectedIndex = this.cmbComision.FindString((col.GetOne((cl.GetOne(_AlumnoInscripcionActual.IDCurso).IDComision)).Descripcion));
            this.cmbCondicion.SelectedIndex = this.cmbCondicion.FindString(_AlumnoInscripcionActual.Condicion);
            

            //Bloqueamos el combo de condicion salvo que sea admin
            if (!(((pl.GetOne(_AlumnoInscripcionActual.IDAlumno)).Tipo.ToString()).Equals("Admin")))
            {
                this.cmbCondicion.Enabled = false;
            }


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
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    _AlumnoInscripcionActual = ai;
                    _AlumnoInscripcionActual.Condicion = "Inscripto";

                    int  idMat = ml.GetPorDescripcion(cmbMateria.SelectedItem.ToString()).ID;
                    int idComision = col.GetPorDescripcion(cmbComision.SelectedItem.ToString()).ID;
                    Curso cu = cl.GetCurso(idMat,idComision);

                    _AlumnoInscripcionActual.IDCurso = cu.ID;
                    _AlumnoInscripcionActual.IDAlumno = idAlumno;

                    _AlumnoInscripcionActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    //falta inhabilitar el combo a los usuarios no admin
                    _AlumnoInscripcionActual.Condicion = cmbCondicion.SelectedItem.ToString(); 
                    idMat = ml.GetPorDescripcion(cmbMateria.SelectedItem.ToString()).ID;
                    idComision = col.GetPorDescripcion(cmbComision.SelectedItem.ToString()).ID;
                    cu = cl.GetCurso(idMat, idComision);

                    _AlumnoInscripcionActual.IDCurso = cu.ID;
                    _AlumnoInscripcionActual.IDAlumno = idAlumno;

                    _AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    _AlumnoInscripcionActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    _AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            ail.Save(_AlumnoInscripcionActual);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        ////Con este metodo modificamos el combo de comisiones en funcion del combo de materias
        //private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        //    ComboBox senderComboBox = (ComboBox)sender;
        //    MessageBox.Show("holaa", "asad", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}



    }
}