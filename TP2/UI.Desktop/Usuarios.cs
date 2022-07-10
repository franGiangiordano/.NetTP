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
            cmbCriterio.Items.Add("ID Usuario");
            cmbCriterio.Items.Add("Nombre Usuario");
            dgvUsuarios.AutoGenerateColumns = false;
            Listar();
            
        }

        
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();            
        }

        public void ListarBusqueda()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.BusquedaUsuario(cmbCriterio.SelectedIndex, txtBusqueda.Text);
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
            txtBusqueda.Text = "Buscar"; //esto es para el placeholder
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
            //validamos los campos para la bsuqueda
            int n;
            if (String.IsNullOrEmpty(this.txtBusqueda.Text) || cmbCriterio.SelectedIndex.Equals(-1))
            {
                this.Notificar("Existe campo vacio o no se selecciono un criterio de busqueda\n Rellenelos antes de continuar\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (cmbCriterio.SelectedIndex.Equals(0))
            {
                if (!int.TryParse(this.txtBusqueda.Text, out n))
                {
                    this.Notificar("El campo de busqueda por ID de Usuario no admite letras, solo numeros\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.ListarBusqueda();
                }
            }
            if (cmbCriterio.SelectedIndex.Equals(1))
            {
                if (!this.txtBusqueda.Text.All(Char.IsLetter))
                {
                    this.Notificar("El campo de busqueda por Nombre de Usuario no admite numeros, solo letras\n", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    this.ListarBusqueda();
                }
            }
            
        }
         //esto es para el placeholder
        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Buscar");
            {
                txtBusqueda.Text = "";
            }
        }
        //esto es para el placeholder
        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                txtBusqueda.Text = "Buscar";
            }
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
