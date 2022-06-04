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
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
            Listar();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar() {

            PersonaLogic ul = new PersonaLogic();
            this.dgvPersonas.DataSource = ul.GetAll();
            //Este es un artilugio para asociar el id de plan al nombre
            //Es temporal hasta que se integre a una DB
            for (int i = 0; i < this.dgvPersonas.Rows.Count; i++) {
                if (dgvPersonas.Rows[i].Cells[10].Value.ToString().Equals("0"))
                {
                    this.dgvPersonas.Rows[i].Cells[10].Value = "1996";
                }
                else if (dgvPersonas.Rows[i].Cells[10].Value.ToString().Equals("1"))
                {
                    this.dgvPersonas.Rows[i].Cells[10].Value = "2008";
                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcPersonas_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPersonas.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPersonas.ShowDialog();
            this.Listar();
        }
    }
}
