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
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
            dvgBusquedaUsuario.AutoGenerateColumns = false;
            Listar();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool Validar()
        {
            if (String.IsNullOrEmpty(this.txtBusqueda.Text))
            {
                MessageBox.Show("Existen uno o mas campos vacios, rellenelos antes de continuar\n") ;
            }
        return true;
        }
            private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (Validar()) { 
             UsuarioLogic ul = new UsuarioLogic();
                 if (ul.BusquedaUsuario(cmbCriterio.SelectedIndex, txtBusqueda.Text).Count == 0)
                 {
                     MessageBox.Show("No se encontro usuario");
                 }
                else
                 {
                    this.dvgBusquedaUsuario.DataSource = ul.BusquedaUsuario(cmbCriterio.SelectedIndex, txtBusqueda.Text);
                 }
            }




        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dvgBusquedaUsuario.DataSource = ul.GetAll();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //UsuarioLogic ul = new UsuarioLogic();
            //dvgBusquedaUsuario.DataSource = ul.BusquedaUsuario(cmbCriterio.SelectedIndex, txtBusqueda.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
