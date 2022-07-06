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



//ver como manejar el tema de los permisos
//agregar parametro global al form principal

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
            validarPermisos();
        }

        private void validarPermisos()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripciones");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);

            if (!mu.PermiteAlta) //es Docente
            {
                this.tsbNuevo.Visible = false;
                this.tsbEliminar.Visible = false;
            } else if (!mu.PermiteModificacion) { //es Alumno 
                this.tsbEditar.Visible = false;                
            } 

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
            ComisionLogic coml = new ComisionLogic();
            EspecialidadLogic espl = new EspecialidadLogic();
            PlanLogic planl = new PlanLogic();


            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id_inscripcion", typeof(int)); //los nombres de las columnas tienen que coincidir con los definidos en el Smart Tag
            dt1.Columns.Add("id_alumno", typeof(string));
            dt1.Columns.Add("id_curso", typeof(string));
            dt1.Columns.Add("condicion", typeof(string));
            dt1.Columns.Add("nota", typeof(string));
            dt1.Columns.Add("anio", typeof(int));
            dt1.Columns.Add("materia", typeof(string));
            dt1.Columns.Add("comision", typeof(string));
            dt1.Columns.Add("especialidad", typeof(string));

            foreach (var ins in l1)
            {
                Persona al = pl.GetOne(ins.IDAlumno);
                Curso cur = cl.GetOne(ins.IDCurso);
                Materia mat = ml.GetOne(cur.IDMateria);
                Comision com = coml.GetOne(cur.IDComision);
                Plan plan = planl.GetOne(al.IDPlan);
                Especialidad esp = espl.GetOne(plan.IDEspecialidad);


                dt1.Rows.Add(ins.ID, al.Nombre + ' ' + al.Apellido ,cur.ID, ins.Condicion, ins.Nota != -1 ? ins.Nota.ToString() : null, cur.AnioCalendario, mat.Descripcion,com.Descripcion,esp.Descripcion);
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
