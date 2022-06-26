using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class AlumnoInscripciones : Form
    {
        int id;

        public AlumnoInscripciones(int idPersona)
        {
            InitializeComponent();
            id = idPersona;
        }

        
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(id);
            alumnoInscripcionDesktop.ShowDialog();

        }
    }
}
