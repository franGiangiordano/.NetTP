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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            Listar();
           // validarPermisos();
        }


        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("Comisiones");
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
            ComisionLogic pl = new ComisionLogic();
            List<Comision> l1 = pl.GetAll();


            PlanLogic el = new PlanLogic();
            List<Plan> l2 = el.GetAll();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("Descripcion", typeof(string));
            dt1.Columns.Add("anio", typeof(int));
            dt1.Columns.Add("idplan", typeof(string));

            foreach (var com in l1)
            {
                dt1.Rows.Add(com.ID, com.Descripcion,com.AnioEspecialidad, l2.Find(x => x.ID == com.IDPlan).Descripcion);
            }
            this.dgvComisiones.DataSource = dt1;
        }
       

        private void Comisiones_Load(object sender, EventArgs e)
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
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.Rows.Count != 0)
            {
                int ID = Convert.ToInt32(dgvComisiones.Rows[dgvComisiones.CurrentRow.Index].Cells[0].Value);
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.Rows.Count != 0)
            {
                int ID = Convert.ToInt32(dgvComisiones.Rows[dgvComisiones.CurrentRow.Index].Cells[0].Value);
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
            }
        }
    }
}
