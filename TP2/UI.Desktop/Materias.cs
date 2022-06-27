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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            Listar();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> l1 = ml.GetAll();

            PlanLogic pl = new PlanLogic();
            List<Plan> l2 = pl.GetAll();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("Descripcion", typeof(string));
            dt1.Columns.Add("HSSemanales", typeof(string));
            dt1.Columns.Add("HSTotales", typeof(string));
            dt1.Columns.Add("IdPlan", typeof(string));

            

            foreach (var mat in l1)
            {             
                dt1.Rows.Add(mat.ID, mat.Descripcion, mat.HSSemanales,mat.HSTotales, l2.Find(x => x.ID == mat.IDPlan).Descripcion);
            }
            this.dgvMaterias.DataSource = dt1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.Rows.Count != 0) {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[0].Value);
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMateria.ShowDialog();
                this.Listar();
            }            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (dgvMaterias.Rows.Count != 0) {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvMaterias.Rows[dgvMaterias.CurrentRow.Index].Cells[0].Value);
                MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMateria.ShowDialog();
                this.Listar();
            }            
        }

        private void tcMaterias_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
