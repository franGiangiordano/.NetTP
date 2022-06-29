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
    public partial class Usuarios : Form
    {
        
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            Listar();
            
        }

        
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();            
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            if (dgvUsuarios.Rows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
                this.Listar();
            }

            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.Rows.Count != 0) {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
                this.Listar();
            }            
        }

        private void tcUsuarios_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            Busqueda formBusqueda = new Busqueda();
            formBusqueda.ShowDialog();
            this.Listar();
        }
    }
}
