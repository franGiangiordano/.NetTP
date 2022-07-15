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
    public partial class AlumnoInscripciones : Form
    {
        public static int idPersona;

        public static int IdPersona { get => idPersona; set => idPersona = value; }
        

        public AlumnoInscripciones()
        {            
            InitializeComponent();
            dgvAlumnosInscripciones.AutoGenerateColumns = false;

            UsuarioLogic ul = new UsuarioLogic();
            IdPersona  = ul.GetOne(Principal.Id).IdPersona;
            Listar();
            validarPermisos();
            cargarCombos();
        }

        private void cargarCombos()
        {            
           ComisionLogic cl = new ComisionLogic();
           MateriaLogic ml = new MateriaLogic();

           this.cmbFiltroComision.ComboBox.DataSource = cl.GetDescripciones();
           this.cmbFiltroComision.ComboBox.DisplayMember = "Descripcion";
           this.cmbFiltroComision.ComboBox.ValueMember = "ID";
           this.cmbFiltroComision.ComboBox.SelectedIndexChanged += new System.EventHandler(cmbFiltroComision_SelectedIndexChanged);

            this.cmbFiltroMateria.ComboBox.DataSource = ml.GetDescripciones();
            this.cmbFiltroMateria.ComboBox.DisplayMember = "Descripcion";
            this.cmbFiltroMateria.ComboBox.ValueMember = "ID";
            this.cmbFiltroMateria.ComboBox.SelectedIndexChanged += new System.EventHandler(cmbFiltroComision_SelectedIndexChanged);
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
                this.cmbFiltroComision.ComboBox.Enabled = false;
                this.cmbFiltroMateria.ComboBox.Enabled = false;
            } 

        }

        private void AlumnoInscripciones_Load(object sender, EventArgs e)
        {
            Listar();            
        }

        public void Listar()
        {
            

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            PersonaLogic pl = new PersonaLogic();
            Persona per = pl.GetOne(idPersona);
            List<AlumnoInscripcion> l1 = new List<AlumnoInscripcion>();

            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripciones");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);            

            if (mu.PermiteAlta && mu.PermiteBaja && mu.PermiteModificacion)
            {
                l1 = ail.GetAll();
            }
            else if (mu.PermiteAlta)
            {
                l1 = ail.GetInscripcionesAlumno(idPersona);
            }
            else {
                l1 = ail.GetInscripcionesDocente(idPersona);
            }

            /*if ((int)per.Tipo == 2)
            {  // es Admin, con lo cual debemos mostrar todas las inscripciones
                l1 = ail.GetAll();
            }
            else if ((int)per.Tipo == 0) //es Alumno, con lo cual debemos mostrar todas sus inscripciones 
            {
                l1 = ail.GetInscripcionesAlumno(idPersona);
            }
            else {  //es docente
                l1 = null;
            }*/

            

            
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
            AlumnoInscripcionDesktop alumnoInscripcionDesktop = new AlumnoInscripcionDesktop(idPersona);            
            alumnoInscripcionDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnosInscripciones.Rows.Count != 0) {
                // int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                int ID = Convert.ToInt32(dgvAlumnosInscripciones.Rows[dgvAlumnosInscripciones.CurrentRow.Index].Cells[0].Value);
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(idPersona, ID, ApplicationForm.ModoForm.Modificacion);
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
                AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(idPersona, ID, ApplicationForm.ModoForm.Baja);
                formAlumnoInscripcion.ShowDialog();
                this.Listar();
            }            
        }

        private void cmbFiltroComision_SelectedIndexChanged(object sender, EventArgs e)
        {

            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            ListarFiltro(al.FiltrarPorComision(idPersona, (int)cmbFiltroComision.ComboBox.SelectedValue, (int)cmbFiltroMateria.ComboBox.SelectedValue));
        }


        private void ListarFiltro(List<AlumnoInscripcion> lista)
        {
            PersonaLogic pl = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            MateriaLogic ml = new MateriaLogic();
            ComisionLogic coml = new ComisionLogic();
            EspecialidadLogic espl = new EspecialidadLogic();
            PlanLogic planl = new PlanLogic();

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("id_inscripcion", typeof(int)); 
            dt1.Columns.Add("id_alumno", typeof(string));
            dt1.Columns.Add("id_curso", typeof(string));
            dt1.Columns.Add("condicion", typeof(string));
            dt1.Columns.Add("nota", typeof(string));
            dt1.Columns.Add("anio", typeof(int));
            dt1.Columns.Add("materia", typeof(string));
            dt1.Columns.Add("comision", typeof(string));
            dt1.Columns.Add("especialidad", typeof(string));

            foreach (var ins in lista)
            {
                Persona al = pl.GetOne(ins.IDAlumno);
                Curso cur = cl.GetOne(ins.IDCurso);
                Materia mat = ml.GetOne(cur.IDMateria);
                Comision com = coml.GetOne(cur.IDComision);
                Plan plan = planl.GetOne(al.IDPlan);
                Especialidad esp = espl.GetOne(plan.IDEspecialidad);


                dt1.Rows.Add(ins.ID, al.Nombre + ' ' + al.Apellido, cur.ID, ins.Condicion, ins.Nota != -1 ? ins.Nota.ToString() : null, cur.AnioCalendario, mat.Descripcion, com.Descripcion, esp.Descripcion);
            }
            this.dgvAlumnosInscripciones.DataSource = dt1;
        }
    }
}
