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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.CellClick += dgvCursos_CellClick; //Asociamos el evento del boton Ver Detalles al formulario
            dgvCursos.AutoGenerateColumns = false; 
            Listar();
            validarPermisos();
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("Cursos");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);

            if (!mu.PermiteAlta)
            {
                //ocultamos los btn alta, editar y eliminar
                this.tsbEditar.Visible= false;
                this.tsbNuevo.Visible = false;
                this.tsbEliminar.Visible = false;
            }

        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> l1 = cl.GetAll();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ID", typeof(int)); 
            dt1.Columns.Add("Comision", typeof(string));
            dt1.Columns.Add("Materia", typeof(string));
            dt1.Columns.Add("Anio Calendario", typeof(string));
            dt1.Columns.Add("Cupo", typeof(int));

            //Esto es para agregar el boton al DatGridView
            DataGridViewButtonColumn botonDocentes = new DataGridViewButtonColumn();
            botonDocentes.Name = "Docentes";
            botonDocentes.Text = "Ver Docentes";
            botonDocentes.UseColumnTextForButtonValue = true; //IMPORTANTE! Para que muestre el texto en el boton
            botonDocentes.FlatStyle = FlatStyle.Popup;
            botonDocentes.CellTemplate.Style.BackColor = Color.FromArgb(216, 232, 241);

            int columnIndex = 5;
            if (dgvCursos.Columns["Docentes"] == null)
            {
                dgvCursos.Columns.Insert(columnIndex, botonDocentes);
            }            



            foreach (var cu in l1)
            {
                MateriaLogic ml = new MateriaLogic();
                Materia materia = ml.GetOne(cu.IDMateria);

                ComisionLogic coml = new ComisionLogic();
                Comision comision = coml.GetOne(cu.IDComision);


                dt1.Rows.Add(cu.ID, materia.Descripcion , comision.Descripcion, cu.AnioCalendario, cu.Cupo);
            }
            this.dgvCursos.DataSource = dt1;

            
        }

        private void Cursos_Load(object sender, EventArgs e)
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
            CursoDesktop formCursoDesktop = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCursoDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count != 0)
            {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvCursos.Rows[dgvCursos.CurrentRow.Index].Cells[0].Value);
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count != 0)
            {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvCursos.Rows[dgvCursos.CurrentRow.Index].Cells[0].Value);
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
                this.Listar();
            }
        }


        private void dgvCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCursos.Columns["Docentes"].Index)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                Docentes formDocentes = new Docentes(ID);
                formDocentes.ShowDialog();
            }
        }

    }
}
