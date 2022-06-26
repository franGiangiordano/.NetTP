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
        public AlumnoInscripcionDesktop(int idPersona)
        {
            InitializeComponent();
            cargarComboMaterias(idPersona);
        }

        public void cargarComboMaterias(int idPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            Persona personaActual = pl.GetOne(idPersona);

            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = ml.GetMateriasPlan(personaActual.IDPlan);
            this.cmbMateria.DataSource = (from mat in materias select mat.Descripcion).ToList();
        }
    }
}
