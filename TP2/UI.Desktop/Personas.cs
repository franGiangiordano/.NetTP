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
            List<Persona> l1 = ul.GetAll();

            PlanLogic pl = new PlanLogic();
            List<Plan> l2 = pl.GetAll();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("Nombre", typeof(string));
            dt1.Columns.Add("Apellido", typeof(string));
            dt1.Columns.Add("Telefono", typeof(string));
            dt1.Columns.Add("Direccion", typeof(string));
            dt1.Columns.Add("Legajo", typeof(int));
            dt1.Columns.Add("FechaNacimiento", typeof(DateTime));
            dt1.Columns.Add("Email", typeof(string));
            dt1.Columns.Add("Tipo", typeof(Persona.TipoPersonas));
            dt1.Columns.Add("Descripcion", typeof(string));


            foreach (var per in l1) {                    
                    dt1.Rows.Add(per.ID,per.Nombre,per.Apellido,per.Telefono,per.Direccion,per.Legajo,per.FechaNacimiento.Date,per.Email,per.Tipo, l2.Find(x => x.ID == per.IDPlan).Descripcion);
            }
            this.dgvPersonas.DataSource = dt1;
                       
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
            //int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            int ID = Convert.ToInt32(dgvPersonas.Rows[dgvPersonas.CurrentRow.Index].Cells[0].Value);
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPersonas.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            //int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            int ID = Convert.ToInt32(dgvPersonas.Rows[dgvPersonas.CurrentRow.Index].Cells[0].Value);
            PersonaDesktop formPersonas = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPersonas.ShowDialog();
            this.Listar();
        }

        private void dgvPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
