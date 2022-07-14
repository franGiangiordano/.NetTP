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
            PersonaLogic ul = new PersonaLogic();
            this.dgvDocentes.DataSource = ul.GetDocentesCurso();            
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
                formUsuario.ShowDialog(); 
                this.Listar(); 
            
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }

            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
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
