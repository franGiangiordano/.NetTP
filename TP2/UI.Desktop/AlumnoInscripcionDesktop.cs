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

//Falta agregar un combo de alumnos para cuando el admin quiera inscribir a un alumno

namespace UI.Desktop
{
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        private Business.Entities.AlumnoInscripcion alumnoInscripcionActual;
        public event EventHandler SelectedIndexChanged; //evento para controlar cuando se elige una materia del combo

        int idAlumno;

        public AlumnoInscripcion AlumnoInscripcionActual { get => alumnoInscripcionActual; set => alumnoInscripcionActual = value; }

        public AlumnoInscripcionDesktop() {
            InitializeComponent();
        }

        public AlumnoInscripcionDesktop(int idPersona)
        {
            InitializeComponent();
            idAlumno = idPersona;
            cargarComboLegajos();
            cargarComboMaterias(idPersona);
            cargarComboComisiones(idPersona);
           // validarMateriasDisponibles();            
            validarPermisos(idPersona);            
        }

        public AlumnoInscripcionDesktop(int idPersona, int ID, ApplicationForm.ModoForm modo) : this()
        {
            // InitializeComponent();
            Modo = (ApplicationForm.ModoForm)modo;

            idAlumno = idPersona;
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AlumnoInscripcionActual = ail.GetOne(ID);
            cargarComboLegajos();
            cargarComboMaterias(idPersona);
            cargarComboComisiones(idPersona);            
           // validarMateriasDisponibles();
            MapearDeDatos();
            validarPermisos(idPersona);

            this.txtNota.Enabled = false;
            this.cmbCondicion.SelectedIndexChanged += new System.EventHandler(cmbCondicion_SelectedIndexChanged); //asociamos el evento al combo            
        }

        private Boolean esDocente() {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);
            return !mu.PermiteAlta;
        }

        private Boolean esAdmin()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);
            return (mu.PermiteAlta && mu.PermiteModificacion);
        }


        private bool Validar(){

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();

            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);
            string errores = "";
           
            if (esDocente())
            {
                //Obligamos al docente a introducir la nota en caso de que desee aprobar a un alumno
                if (((this.cmbCondicion.Text).Equals("Aprobado")) && String.IsNullOrEmpty(this.txtNota.Text))
                {
                    errores += "El campo nota no puede estar vacio\n";
                    this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                //Validamos la nota ingresada
                } else if (((this.cmbCondicion.Text).Equals("Aprobado")) && (!String.IsNullOrEmpty(this.txtNota.Text))) {
                    if (ail.validarNota(this.txtNota.Text))
                    {
                        return true;
                    }
                    else {                                              
                        errores += "El campo nota tiene que tener un valor entero entre 6 y 10\n";
                        this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }      
                }
            }

            if ((ApplicationForm.ModoForm)ModoForm.Alta == Modo) {
                Curso cu = cl.GetCurso((int)this.cmbMateria.SelectedValue, (int)this.cmbComision.SelectedValue);                
                if (cl.TieneCupo(cu))
                {                    
                    return true;
                }
                else
                {
                    errores += "El curso no tiene cupo disponible\n";
                    this.Notificar(errores, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
                return true;    
            
        }

        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void validarPermisos(int idPersona)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Principal.Id);

            if (!mu.PermiteAlta) //es Docente
            {
                this.lblLegajo.Visible = false;
                this.cmbLegajo.Visible = false;
                cmbMateria.Enabled = false;
                cmbComision.Enabled = false;
                cmbCondicion.Enabled = true;
            }
            else if (!mu.PermiteModificacion)
            { //es Alumno 
                this.lblLegajo.Visible = false;
                this.cmbLegajo.Visible = false;
                this.lblCondicion.Visible = false;
                this.lblNota.Visible = false;
                cmbCondicion.Visible = false;
                txtNota.Visible = false;
              //  cargarComboMaterias(idPersona);
              //  cargarComboComisiones(idPersona);
            }
            else { //Para el admin habría que modificar la forma de cargar las inscripciones
                   //Tendriamos que agregar un combo correspondiente al alumno y en funcion de ese alumno
                   //cargar las materias y comisiones o algo x el estilo
                this.lblCondicion.Visible = false;
                this.lblNota.Visible = false;
                cmbCondicion.Visible = false;
                txtNota.Visible = false;
               // cargarComboMaterias(idPersona);
               // cargarComboComisiones(idPersona);
            }

        }

        public void cargarComboMaterias(int idPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            Persona personaActual = pl.GetOne(idPersona);
            MateriaLogic ml = new MateriaLogic();

            List<Materia> materias = null;
            List<Materia> materiasNoDisponibles = null;
            if (esAdmin())
            {
                materias = ml.GetMateriasPlan(pl.GetOne((int)this.cmbLegajo.SelectedValue).IDPlan);  //obtenemos listado de materias
                materiasNoDisponibles = ml.GetMateriasAlumno((int)this.cmbLegajo.SelectedValue); //obtenemos listado de materias inscriptas o aprobadas            
            }
            else {
                materias = ml.GetMateriasPlan(personaActual.IDPlan);  //obtenemos listado de materias
                materiasNoDisponibles = ml.GetMateriasAlumno(idPersona); //obtenemos listado de materias inscriptas o aprobadas            
            }
            
            
            if ((ApplicationForm.ModoForm)ModoForm.Alta == Modo)
            {                
                //calculamos la diferencia
                this.cmbMateria.DataSource = materias.Where(item => !materiasNoDisponibles.Any(e => item.ID == e.ID)).ToList();
            }
            else {
                Materia materiaActual = ml.GetOne(cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria);
                this.cmbMateria.DataSource = (materias.Where(item => !materiasNoDisponibles.Any(e => (item.ID == e.ID) && (item.ID != materiaActual.ID))).ToList());
            }
            

            this.cmbMateria.DisplayMember = "Descripcion";
            this.cmbMateria.ValueMember = "ID";
            this.cmbMateria.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged); //asociamos el evento al combo            
        }

        private void cargarComboComisiones(int idPersona)
        {            
            if (!string.IsNullOrEmpty(this.cmbMateria.Text)) {
                PersonaLogic pl = new PersonaLogic();
                Persona personaActual = null;
                if (esAdmin())
                {
                    personaActual = pl.GetOne((int)this.cmbLegajo.SelectedValue);
                }
                else {
                   personaActual = pl.GetOne(idPersona);
                }
                
                ComisionLogic cl = new ComisionLogic();
                this.cmbComision.DataSource = cl.GetComisionesPlan(personaActual.IDPlan, (int)this.cmbMateria.SelectedValue);
                this.cmbComision.DisplayMember = "Descripcion";
                this.cmbComision.ValueMember = "ID";
            }            
        }

        private void cargarComboLegajos()
       {
                PersonaLogic pl = new PersonaLogic();
                List<Persona> legajos = pl.GetLegajosAlumnos();
                this.cmbLegajo.DataSource = legajos;
                this.cmbLegajo.DisplayMember = "Legajo";
                this.cmbLegajo.ValueMember = "ID";
                
        }


        public override void MapearDeDatos()
        {
            MateriaLogic ml = new MateriaLogic();            
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            PersonaLogic pl = new PersonaLogic();

            this.txtIDInscripcion.Text = this.AlumnoInscripcionActual.ID.ToString();

            this.cmbLegajo.SelectedValue = this.AlumnoInscripcionActual.IDAlumno;
            //Esta linea sirve para obtener el indice de una Materia            
            this.cmbMateria.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria;
            //this.cmbMateria.SelectedValue = (int)this.cmbMateria.FindString(ml.GetOne((cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria)).Descripcion);
            this.cmbComision.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision;
            //this.cmbComision.SelectedValue = this.cmbComision.FindString((col.GetOne((cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision)).Descripcion));
            //this.cmbCondicion.SelectedIndex = this.cmbCondicion.FindString(AlumnoInscripcionActual.Condicion);
            if (this.alumnoInscripcionActual.Nota != -1) {
                this.txtNota.Text = this.alumnoInscripcionActual.Nota.ToString();
            }            
            //Bloqueamos el combo de condicion salvo que sea admin
            if (!(((pl.GetOne(AlumnoInscripcionActual.IDAlumno)).Tipo.ToString()).Equals("Administrador")))
            {
                this.cmbCondicion.Enabled = false;
            }

            if (esDocente()) {
                this.cmbCondicion.SelectedItem = alumnoInscripcionActual.Condicion.ToString();
                if (alumnoInscripcionActual.Nota == -1) {
                    this.txtNota.Text = "";
                }
                this.txtNota.Text = alumnoInscripcionActual.Nota.ToString();
            }

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:                   
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }


        public override void MapearADatos()
        {
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();

            int idMat;
            int idComision;

            switch (Modo)
            {
                case (ApplicationForm.ModoForm)ModoForm.Alta:

                    Curso cu = cl.GetCurso((int)this.cmbMateria.SelectedValue, (int)this.cmbComision.SelectedValue);
                    cu.Cupo -= 1;
                    cl.Update(cu);   
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    AlumnoInscripcionActual = ai;
                    AlumnoInscripcionActual.Condicion = "Inscripto";
                    AlumnoInscripcionActual.IDCurso = cu.ID;
                    if (esAdmin())
                    {
                        AlumnoInscripcionActual.IDAlumno = (int)this.cmbLegajo.SelectedValue;
                    }
                    else {
                        AlumnoInscripcionActual.IDAlumno = idAlumno;
                    }
                    
                    AlumnoInscripcionActual.State = Usuario.States.New;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Modificacion:
                    //Si es docente, asignamos la materia y comision que estaban antes
                    if (esDocente()) 
                    {
                        AlumnoInscripcionActual.Condicion = cmbCondicion.SelectedItem.ToString();
                        idMat = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria;
                        idComision = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision;
                        
                        //Si acaba de aprobar a un alumno, leemos la nota 
                        if ((this.cmbCondicion.Text).Equals("Aprobado")) {
                            AlumnoInscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                        }
                    }
                    else {
                        idMat = (int)this.cmbMateria.SelectedValue;
                        idComision = (int)this.cmbComision.SelectedValue;
                    }

                    if (esAdmin())
                    {
                        AlumnoInscripcionActual.IDAlumno = (int)this.cmbLegajo.SelectedValue;
                    }
                    else
                    {
                        AlumnoInscripcionActual.IDAlumno = idAlumno;
                    }

                    cu = cl.GetCurso(idMat, idComision);
                    AlumnoInscripcionActual.IDCurso = cu.ID;                    
                    AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Baja:
                    AlumnoInscripcionActual.State = Usuario.States.Deleted;
                    break;

                case (ApplicationForm.ModoForm)ModoForm.Consulta:
                    AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;
            }            
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            ail.Save(AlumnoInscripcionActual);
             
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bntAceptar_Click(object sender, EventArgs e)
        {            
                if (Validar())
                {
                    GuardarCambios();
                    Close();
                }           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
            botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }


        ////Con este metodo modificamos el combo de comisiones en funcion del combo de materias
        ///El objetivo de este metodo es obtener las comisiones para una materia dada
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            cargarComboComisiones(idAlumno);
            //ComboBox senderComboBox = (ComboBox)sender;

            //senderComboBox.DataSource = cl.GetComisionesDeMateria(cmbMateria.SelectedItem.ToString());


        }

        private void cmbCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCondicion.SelectedItem.ToString().Equals("Aprobado")) {
                this.txtNota.Enabled = true;
            }


        }

        

        private void validarMateriasDisponibles() {
            if (((this.cmbMateria.Items.Count == 0) || (this.cmbCondicion.Items.Count == 0)) && (!esDocente()) && (!esAdmin()))
            {
                this.Notificar("No hay ninguna materia disponible para inscrbirse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }

        }

        private void AlumnoInscripcionDesktop_Load(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
