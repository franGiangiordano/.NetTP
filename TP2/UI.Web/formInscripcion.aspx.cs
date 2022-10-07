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
                cargarComboLegajos();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Inscripciones.aspx");
            }
            else if (Session["estado"].Equals("modificacion"))
            {
                //Tenemos que guardar en el ViewState los datos ingresados para conservarlos entre postbacks
                //CargarViewStates();

                //MapearDeDatos();
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
            //this.cmbMateria.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged); //asociamos el evento al combo            
        }

        private Boolean esAdmin()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            int idModulo = mul.GetIdModulo("AlumnoInscripcionDesktop");
            ModuloUsuario mu = mul.GetModuloUsuario(idModulo, Int32.Parse(Session["id"].ToString()));
            return (mu.PermiteAlta && mu.PermiteModificacion);
        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}