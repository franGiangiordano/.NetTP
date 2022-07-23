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
using Negocio;



namespace UI.Desktop
{
    public partial class Docentes : Form
    {
        private int idCurso;

        public int IdCurso { get => idCurso; set => idCurso = value; }

        public Docentes()
        {
            InitializeComponent();
            dgvDocentes.AutoGenerateColumns = false;
            Listar();
            
        }

        public Docentes (int ID)
        {
            InitializeComponent();
            dgvDocentes.AutoGenerateColumns = false;
            idCurso = ID;
            Listar();
        }

        
        public void Listar()
        {
            DocenteCursoLogic ul = new DocenteCursoLogic();
            this.dgvDocentes.DataSource = ul.GetDocentesCurso(idCurso);            
        }

        private void Docentes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoLogic ul = new DocenteCursoLogic();
            if (ul.GetDocentesCurso(idCurso).Count < 3)
            {
                DocenteDesktop formDocente = new DocenteDesktop(idCurso);
                formDocente.ShowDialog();
                this.Listar();
            }
            else {
                this.Notificar("Ya se alcanzó el tope de docentes para el curso\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count != 0) {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(idCurso,ID, ApplicationForm.ModoForm.Modificacion);
                formDocente.ShowDialog();
                this.Listar();
            }

            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count != 0) {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                DocenteDesktop formDocente = new DocenteDesktop(idCurso, ID, ApplicationForm.ModoForm.Baja);
                formDocente.ShowDialog();
                this.Listar();
            }            
        }

        private void tcUsuarios_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        public  void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public  void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
    }
}
