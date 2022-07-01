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
    public partial class Principal : ApplicationForm
    {
        int id;

        public Principal()
        {
            InitializeComponent();
        }

        public Principal(int idUsuario)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e) //es el del listado
        {
            if (!pListado.Visible)
            {
                pListado.Visible = true;
            }
            else
            {
                pListado.Visible = false;
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }

        private void btnCurso_Click_1(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos();
            formCursos.ShowDialog();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog();
        }

        private void btnMateria_Click_1(object sender, EventArgs e)
        {
            Materias formMaterias = new Materias();
            formMaterias.ShowDialog();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            AlumnoInscripciones alumnoInscripciones = new AlumnoInscripciones(4);
            alumnoInscripciones.ShowDialog();
        }
    }
}
