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
            this.dgvMaterias.DataSource = ml.GetAll();
            //Este es un artilugio para asociar el id de plan al nombre
            //Es temporal hasta que se integre a una DB
            for (int i = 0; i < this.dgvMaterias.Rows.Count; i++)
            {
                if (dgvMaterias.Rows[i].Cells[4].Value.ToString().Equals("0"))
                {
                    this.dgvMaterias.Rows[i].Cells[4].Value = "1996";
                }
                else if (dgvMaterias.Rows[i].Cells[4].Value.ToString().Equals("1"))
                {
                    this.dgvMaterias.Rows[i].Cells[4].Value = "2008";
                }
            }
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
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(ID,ApplicationForm.ModoForm.Modificacion);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(ID,ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            this.Listar();
        }
    }
}
