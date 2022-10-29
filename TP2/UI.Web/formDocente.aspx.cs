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
    public partial class formDocente : System.Web.UI.Page
    {
        private Business.Entities.DocenteCurso _DocenteCursoActual;

        public DocenteCurso DocenteCursoActual { get => _DocenteCursoActual; set => _DocenteCursoActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarComboDocentes();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Docentes.aspx");
            }
            else if (Session["estado"].Equals("modificacion"))
            {
                string id = (string)Session["idDocenteCurso"];
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                DocenteCursoActual = new DocenteCurso();
                DocenteCursoActual = dcl.GetOne(Int32.Parse(id));

                CargarViewStates();

                MapearDeDatos();
            }
        }

        private void cargarComboDocentes()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = pl.GetLegajosDocentes();

            DocenteCursoLogic ml = new DocenteCursoLogic();
            DocenteCursoActual = ml.GetOne(Int32.Parse(Session["idDocenteCurso"].ToString()));

            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> docentesNoDisponibles = dcl.GetDocentesNoDisponibles(Int32.Parse(Session["id"].ToString()));

            if (Session["estado"].Equals("alta"))
            {
                //calculamos la diferencia
                this.cmbLegajo.DataSource = docentes.Where(item => !docentesNoDisponibles.Any(e => item.ID == e.IDDocente)).ToList();
            }
            else
            {
                //Materia materiaActual = ml.GetOne(cl.GetOne(AlumnoInscripcionActual.IDCurso).IDMateria);
                this.cmbLegajo.DataSource = (docentes.Where(item => !docentesNoDisponibles.Any(e => (item.ID == e.IDDocente) && (item.ID != DocenteCursoActual.IDDocente))).ToList());
            }
            this.cmbLegajo.DataTextField = "Legajo";
            this.cmbLegajo.DataValueField = "ID";
            this.cmbLegajo.DataBind();
            this.cmbLegajo.SelectedIndexChanged += new System.EventHandler(cmbLegajo_SelectedIndexChanged);
            Persona docente = pl.GetOne(Int32.Parse(cmbLegajo.SelectedValue));
            this.lblNombre.Text = "" + docente.Nombre + " " + docente.Apellido;
        }

        private void CargarViewStates()
        {
            ViewState["legajo"] = cmbLegajo.SelectedValue;
            ViewState["cargo"] = cmbCargo.SelectedValue;
        }

        public void MapearADatos()
        {
            switch (Session["estado"])
            {
                case "alta":
                    DocenteCurso doc = new DocenteCurso();
                    DocenteCursoActual = doc;
                    DocenteCursoActual.IDDocente = Int32.Parse(this.cmbLegajo.SelectedValue);
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), cmbCargo.SelectedItem.ToString());
                    DocenteCursoActual.IDCurso = Int32.Parse(Session["id"].ToString());
                    DocenteCursoActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    DocenteCursoActual.IDDocente = Int32.Parse((string)ViewState["legajo"]);
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), (string)ViewState["cargo"]);
                    DocenteCursoActual.IDCurso = Int32.Parse(Session["id"].ToString());
                    DocenteCursoActual.State = Usuario.States.Modified;
                    break;
            }
        }

        private void MapearDeDatos()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            PersonaLogic pl = new PersonaLogic();
            

            if (!Page.IsPostBack)
            {
                string id = (string)Session["idDocenteCurso"];
               
                

                this.cmbLegajo.SelectedValue = this.DocenteCursoActual.IDDocente.ToString();
                this.cmbCargo.SelectedValue = this.DocenteCursoActual.Cargo.ToString();

                Persona docente = pl.GetOne(Int32.Parse(cmbLegajo.SelectedValue));
                this.lblNombre.Text = "" + docente.Nombre + " " + docente.Apellido;
            }
            else
            {
                this.cmbLegajo.SelectedValue = (string)ViewState["legajo"];
                this.cmbCargo.SelectedValue = (string)ViewState["cargo"];
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


        public void GuardarCambios()
        {
            try
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                MapearADatos();
                if (Session["estado"].Equals("modificacion") || Session["estado"].Equals("alta"))
                {
                    if (dcl.validarDocenteCargo(DocenteCursoActual))
                    {
                        dcl.Save(DocenteCursoActual);
                    }
                    else
                    {
                        Response.Write("<script>alert('No se admiten tres ayudantes en un mismo curso sin un docente');</script>");
                    }
                }
                else
                {
                    dcl.Save(DocenteCursoActual);
                }

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al ejecutar la operacion", Ex);
                throw ExcepcionManejada;
                
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCambios();
                Session.Remove("estado"); //cerramos una sesion en particular
                //Response.Write("<script>history.go(-1)</script>");
                Response.Redirect("~/Docentes.aspx");
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar datos del docente", ex);
                Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Docentes.aspx");
        }

        protected void cmbLegajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["estado"].Equals("alta"))
            {
                if (this.cmbLegajo.SelectedValue.ToString() != null)
                {
                    PersonaLogic pl = new PersonaLogic();
                    Persona docente = pl.GetOne(Int32.Parse(cmbLegajo.SelectedValue));
                    this.lblNombre.Text = "" + docente.Nombre + " " + docente.Apellido;
                }
            }else if (Session["estado"].Equals("modificacion"))
            {
                if (this.cmbLegajo.SelectedValue.ToString() != null)
                {
                    PersonaLogic pl = new PersonaLogic();
                    Persona docente = pl.GetOne(Int32.Parse((string)ViewState["legajo"]));
                    this.lblNombre.Text = "" + docente.Nombre + " " + docente.Apellido;
                }
            }
            
        }
    }
}