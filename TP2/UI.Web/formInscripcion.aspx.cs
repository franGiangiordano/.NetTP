using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class formInscripcion : System.Web.UI.Page

    {
        private Business.Entities.AlumnoInscripcion alumnoInscripcionActual;

        public AlumnoInscripcion AlumnoInscripcionActual { get => alumnoInscripcionActual; set => alumnoInscripcionActual = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = ((Usuario)Session["usuario"]).IdPersona;
                cargarComboLegajos();
                cargarComboMaterias(id);
                cargarComboComisiones(id);
                validarPermisos(id);
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Inscripciones.aspx");
            }
            else if (Session["estado"].Equals("modificacion"))
            {
                //Tenemos que guardar en el ViewState los datos ingresados para conservarlos entre postbacks
                CargarViewStates();

                MapearDeDatos();

                this.txtNota.Enabled = false;
            }
        }

        public void cargarComboLegajos()
        {

            PersonaLogic pl = new PersonaLogic();
            List<Persona> legajos = pl.GetLegajosAlumnos();
            this.cmbLegajo.DataSource = legajos;
            this.cmbLegajo.DataTextField = "Legajo";
            this.cmbLegajo.DataValueField = "ID";
            this.cmbLegajo.DataBind();
        }
        public void cargarComboMaterias(int idPersona)
        {
            PersonaLogic pl = new PersonaLogic();
            CursoLogic cl = new CursoLogic();
            Persona personaActual = pl.GetOne(idPersona);
            MateriaLogic ml = new MateriaLogic();

            List<Materia> materias = null;
            List<Materia> materiasNoDisponibles = null;

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AlumnoInscripcionActual = ail.GetOne(((Usuario)Session["usuario"]).IdPersona);

            if (esAdmin())
            {
                materias = ml.GetMateriasPlan(pl.GetOne(Int32.Parse(cmbLegajo.SelectedValue)).IDPlan);  //obtenemos listado de materias
                materiasNoDisponibles = ml.GetMateriasAlumno(Int32.Parse(cmbLegajo.SelectedValue)); //obtenemos listado de materias inscriptas o aprobadas            
            }
            else
            {
                materias = ml.GetMateriasPlan(personaActual.IDPlan);  //obtenemos listado de materias
                materiasNoDisponibles = ml.GetMateriasAlumno(idPersona); //obtenemos listado de materias inscriptas o aprobadas            
            }



            if (Session["estado"].Equals("alta"))
            {
                //calculamos la diferencia
                this.cmbMateria.DataSource = materias.Where(item => !materiasNoDisponibles.Any(e => item.ID == e.ID)).ToList();
            }
            else
            {
                Materia materiaActual = ml.GetOne(cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria);
                this.cmbMateria.DataSource = (materias.Where(item => !materiasNoDisponibles.Any(e => (item.ID == e.ID) && (item.ID != materiaActual.ID))).ToList());
            }
            

            this.cmbMateria.DataTextField = "Descripcion";
            this.cmbMateria.DataValueField = "ID";
            this.cmbMateria.DataBind();
            //this.cmbMateria.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged); //asociamos el evento al combo            
        }

        private void cargarComboComisiones(int idPersona)
        {
            if (!string.IsNullOrEmpty(this.cmbMateria.Text))
            {
                PersonaLogic pl = new PersonaLogic();
                Persona personaActual = null;
                if (esAdmin())
                {
                    personaActual = pl.GetOne(Int32.Parse(this.cmbLegajo.SelectedValue));
                }
                else
                {
                    personaActual = pl.GetOne(idPersona);
                }

                ComisionLogic cl = new ComisionLogic();
                this.cmbComision.DataSource = cl.GetComisionesPlan(personaActual.IDPlan, Int32.Parse(this.cmbMateria.SelectedValue));
                this.cmbComision.DataTextField = "Descripcion";
                this.cmbComision.DataValueField = "ID";
                this.cmbComision.DataBind();
            }
        }

        public void MapearDeDatos()
        {
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();
            PersonaLogic pl = new PersonaLogic();

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AlumnoInscripcionActual = ail.GetOne(Int32.Parse(Session["id"].ToString()));

            this.cmbLegajo.SelectedValue = this.AlumnoInscripcionActual.IDAlumno.ToString();
            //Esta linea sirve para obtener el indice de una Materia            
            this.cmbMateria.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria.ToString(); 
            //this.cmbMateria.SelectedValue = (int)this.cmbMateria.FindString(ml.GetOne((cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria)).Descripcion);
            this.cmbComision.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision.ToString(); 
            //this.cmbComision.SelectedValue = this.cmbComision.FindString((col.GetOne((cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision)).Descripcion));
            //this.cmbCondicion.SelectedIndex = this.cmbCondicion.FindString(AlumnoInscripcionActual.Condicion);
            if (this.alumnoInscripcionActual.Nota != -1)
            {
                this.txtNota.Text = this.alumnoInscripcionActual.Nota.ToString();
            }
            //Bloqueamos el combo de condicion salvo que sea admin
            if (!(((pl.GetOne(AlumnoInscripcionActual.IDAlumno)).Tipo.ToString()).Equals("Administrador")))
            {
                this.cmbCondicion.Enabled = false;
            }

            if (esDocente())
            {
                this.cmbCondicion.SelectedItem.Text = alumnoInscripcionActual.Condicion.ToString();
                if (alumnoInscripcionActual.Nota == -1)
                {
                    this.txtNota.Text = "";
                }
                else
                {
                    this.txtNota.Text = alumnoInscripcionActual.Nota.ToString();
                }

            }

            switch (Session["estado"])
            {
                case "alta":
                    btnAceptar.Text = "Guardar";
                    break;
                case "modificacion":
                    btnAceptar.Text = "Guardar";
                    break;
                case "consulta":
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        private void CargarViewStates()
        {

            ViewState["legajo"] = cmbLegajo.SelectedValue;
            ViewState["materia"] = cmbMateria.SelectedValue;
            ViewState["comision"] = cmbComision.SelectedValue;
            ViewState["condicion"] = cmbCondicion.SelectedValue;
            ViewState["nota"] = txtNota.Text;
        }

        public void MapearADatos()
        {
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();

            int idMat;
            int idComision;

            switch (Session["estado"])
            {
                case "alta":

                    Curso cu = cl.GetCurso(Int32.Parse(this.cmbMateria.SelectedValue), Int32.Parse(this.cmbComision.SelectedValue));
                    cu.Cupo -= 1;
                    cl.Update(cu);
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    AlumnoInscripcionActual = ai;
                    AlumnoInscripcionActual.Condicion = "Inscripto";
                    AlumnoInscripcionActual.Nota = -1;
                    AlumnoInscripcionActual.IDCurso = cu.ID;
                    if (esAdmin())
                    {
                        AlumnoInscripcionActual.IDAlumno = Int32.Parse(this.cmbLegajo.SelectedValue);
                    }
                    else
                    {
                        AlumnoInscripcionActual.IDAlumno = ((Usuario)Session["usuario"]).IdPersona;
                    }

                    AlumnoInscripcionActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    //Si es docente, asignamos la materia y comision que estaban antes
                    if (esDocente())
                    {
                        AlumnoInscripcionActual.Condicion = cmbCondicion.SelectedItem.ToString();
                        idMat = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria;
                        idComision = cl.GetOne(AlumnoInscripcionActual.IDCurso).IDComision;

                        //Si acaba de aprobar a un alumno, leemos la nota 
                        if ((this.cmbCondicion.Text).Equals("Aprobado"))
                        {
                            AlumnoInscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                        }
                    }
                    else
                    {
                        idMat = Int32.Parse(this.cmbMateria.SelectedValue);
                        idComision = Int32.Parse(this.cmbComision.SelectedValue);
                    }

                    if (esAdmin())
                    {
                        AlumnoInscripcionActual.IDAlumno = Int32.Parse(this.cmbLegajo.SelectedValue);
                    }
                    else
                    {
                        AlumnoInscripcionActual.IDAlumno = ((Usuario)Session["usuario"]).IdPersona;
                    }

                    cu = cl.GetCurso(idMat, idComision);
                    AlumnoInscripcionActual.IDCurso = cu.ID;
                    AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;

                case "consulta":
                    AlumnoInscripcionActual.State = Usuario.States.Modified;
                    break;
            }
        }
        private bool esDocente()
        {
            return false;
        }

        private Boolean esAdmin()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);
            return (mu.PermiteAlta && mu.PermiteModificacion);
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(AlumnoInscripcionActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
        }

        private bool validar()
        {

            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            MateriaLogic ml = new MateriaLogic();
            CursoLogic cl = new CursoLogic();
            ComisionLogic col = new ComisionLogic();

            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);

            if (esDocente())
            {
                //Obligamos al docente a introducir la nota en caso de que desee aprobar a un alumno
                if (Session["estado"].Equals("alta") && ((this.cmbCondicion.Text).Equals("Aprobado")) && String.IsNullOrEmpty(this.txtNota.Text))
                {
                    Response.Write("<script>alert('El campo nota no puede estar vacio');</script>");
                    return false;
                    //Validamos la nota ingresada
                }else if((Session["estado"].Equals("modificacion") && (ViewState["condicion"].ToString().Equals("Aprobado")) && String.IsNullOrEmpty(ViewState["nota"].ToString())))
                {
                    Response.Write("<script>alert('El campo nota no puede estar vacio');</script>");
                    return false;
                }
                else if (Session["estado"].Equals("alta") && ((this.cmbCondicion.Text).Equals("Aprobado")) && (!String.IsNullOrEmpty(this.txtNota.Text)))
                {
                    if (ail.validarNota(this.txtNota.Text))
                    {
                        return true;
                    }
                    else
                    {
                        Response.Write("<script>alert('El campo nota tiene que tener un valor entero entre 6 y 10');</script>");
                        return false;
                    }
                }else if (Session["estado"].Equals("modificacion") && (ViewState["condicion"].ToString().Equals("Aprobado") && (!String.IsNullOrEmpty(ViewState["nota"].ToString()))))
                {
                    if (ail.validarNota(ViewState["nota"].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        Response.Write("<script>alert('El campo nota tiene que tener un valor entero entre 6 y 10');</script>");
                        return false;
                    }
                }
            }

            if (Session["estado"].ToString().Equals("alta"))
            {
                Curso cu = cl.GetCurso(Int32.Parse(this.cmbMateria.SelectedValue), Int32.Parse(this.cmbComision.SelectedValue));
                if (cl.TieneCupo(cu))
                {
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('El curso no tiene cupo disponible');</script>");
                }
            }

            return true;

        }

        private void validarPermisos(int idPersona)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, ((Usuario)Session["usuario"]).ID);

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
            else
            { //Para el admin habría que modificar la forma de cargar las inscripciones
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    GuardarCambios();
                    Session.Remove("estado"); //cerramos una sesion en particular
                    Response.Redirect("~/Inscripciones.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos de la Inscripcion", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Inscripciones.aspx");
        }
    }
}