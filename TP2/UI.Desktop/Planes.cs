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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
            Listar();
            //validarPermisos();
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("Planes");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);

            if (!mu.PermiteAlta)
            {
                //ocultamos los btn alta, editar y eliminar
                this.tsbEditar.Visible = false;
                this.tsbNuevo.Visible = false;
                this.tsbBorrar.Visible = false;
            }

        }

        public void Listar()
        {
            //PlanLogic pl = new PlanLogic();
            //this.dgvPlanes.DataSource = pl.GetAll();
            PlanLogic pl = new PlanLogic();
            List<Plan> l1 = pl.GetAll();


            EspecialidadLogic el = new EspecialidadLogic();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("Descripcion", typeof(string));
            dt1.Columns.Add("idEspecialidad", typeof(string));

            foreach (var plan in l1)
            {
                dt1.Rows.Add(plan.ID, plan.Descripcion, plan.Especialidad);
            }
            this.dgvPlanes.DataSource = dt1;
        }
       

        private void Planes_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.Rows.Count != 0)
            {
                int ID = Convert.ToInt32(dgvPlanes.Rows[dgvPlanes.CurrentRow.Index].Cells[0].Value);
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
            }
            

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.Rows.Count != 0)
            {
                int ID = Convert.ToInt32(dgvPlanes.Rows[dgvPlanes.CurrentRow.Index].Cells[0].Value);
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
            }
        }
    }
}
