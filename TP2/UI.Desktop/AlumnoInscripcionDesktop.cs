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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        public Business.Entities.AlumnoInscripcion _AlumnoInscripcionActual;
       // public event EventHandler SelectedIndexChanged; //evento para controlar cuando se elige una materia del combo


        public AlumnoInscripcionDesktop(int idPersona)
        {
            InitializeComponent();
            cargarComboMaterias(idPersona);
            cargarComboComisiones(idPersona);
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

        ////Con este metodo modificamos el combo de comisiones en funcion del combo de materias
        //private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        //    ComboBox senderComboBox = (ComboBox)sender;
        //    MessageBox.Show("holaa", "asad", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //}

    }
}
