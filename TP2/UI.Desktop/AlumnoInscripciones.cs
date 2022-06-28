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


//Faltaria agregar más info al formulario Por ejemplo: los horarios de cursado en esa comisión
//Tenemos que descontar un cupo una vez se inscribe el alumno
//Falta hacer las validaciones de negocio como por ejemplo: Que haya cupo, que la materia que aparece en
//el combo no sea una a la que ya esté inscripto o ya esté aprobada
//Habría que ver cómo manejar el tema de las correlatividades
//Tambien se podrian mostrar mas campos en el listado de inscripciones

namespace UI.Desktop
{
    public partial class AlumnoInscripciones : Form
    {
        int idAlumno;

        public AlumnoInscripciones(int idPersona)
        {
            InitializeComponent();
            dgvAlumnosInscripciones.AutoGenerateColumns = false;
            idAlumno = idPersona;
            Listar();
        }

        private void AlumnoInscripciones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> l1 = ail.GetAll();

            PersonaLogic pl = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id_inscripcion", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("id_alumno", typeof(string));
            dt1.Columns.Add("id_curso", typeof(string));
            dt1.Columns.Add("condicion", typeof(string));
            dt1.Columns.Add("nota", typeof(string));
            dt1.Columns.Add("anio", typeof(int));
            dt1.Columns.Add("materia", typeof(string));

            foreach (var ins in l1)
            {
                Persona al = pl.GetOne(ins.IDAlumno);
                Curso cur = cl.GetOne(ins.IDCurso);
                Materia mat = ml.GetOne(cur.IDMateria);

                dt1.Rows.Add(ins.ID, al.Nombre + ' ' + al.Apellido ,cur.ID, ins.Condicion, ins.Nota != -1 ? ins.Nota.ToString() : null, cur.AnioCalendario, mat.Descripcion);
            }
            this.dgvAlumnosInscripciones.DataSource = dt1;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(idAlumno);
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnosInscripciones.Rows.Count != 0) {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvAlumnosInscripciones.Rows[dgvAlumnosInscripciones.CurrentRow.Index].Cells[0].Value);
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(idAlumno, ID, ApplicationForm.ModoForm.Modificacion);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }            
        }

        private void dgvAlumnosInscripciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnosInscripciones.Rows.Count != 0) {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvAlumnosInscripciones.Rows[dgvAlumnosInscripciones.CurrentRow.Index].Cells[0].Value);
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(idAlumno, ID, ApplicationForm.ModoForm.Baja);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }            
        }
    }
}
