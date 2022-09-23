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
    public partial class formPlanes : System.Web.UI.Page
    {
        private Business.Entities.Plan _PlanActual;

        public Plan PlanActual { get => _PlanActual; set => _PlanActual = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCombo();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Planes.aspx");
            }
            else if (Session["estado"].Equals("modificacion"))
            {
                //Tenemos que guardar en el ViewState los datos ingresados para conservarlos entre postbacks
                CargarViewStates();

                MapearDeDatos();
            }
        }

        private void MapearDeDatos()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            PlanLogic pl = new PlanLogic();

            string id = (string)Session["id"];
            PlanActual = new Plan();
            PlanActual = pl.GetOne(Int32.Parse(id));

            this.txtDescripcion.Text = this.PlanActual.Descripcion;
          
            this.cmbEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad.ToString();

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

        public void MapearADatos()
        {
            switch (Session["estado"])
            {
                case "alta":
                    Plan plan = new Plan();
                    PlanActual = plan;
                    PlanActual.Descripcion = txtDescripcion.Text;
                    PlanActual.IDEspecialidad = Int32.Parse(this.cmbEspecialidad.SelectedValue);
                    PlanActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    PlanActual.Descripcion = (string)ViewState["descripcion"];                    
                    PlanActual.IDEspecialidad = Int32.Parse((string)ViewState["especialidad"]);
                    PlanActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PlanLogic pl = new PlanLogic();
                pl.Save(PlanActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar el plan", Ex);
                throw ExcepcionManejada;

            }
        }

        private void CargarViewStates()
        {
            ViewState["descripcion"] = txtDescripcion.Text;           
            ViewState["especialidad"] = cmbEspecialidad.SelectedValue;
        }

        private void cargarCombo()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.cmbEspecialidad.DataSource = el.GetAll();
            this.cmbEspecialidad.DataTextField = "Descripcion";
            this.cmbEspecialidad.DataValueField = "ID";
            this.cmbEspecialidad.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    GuardarCambios();
                    Session.Remove("estado"); //cerramos una sesion en particular
                    Response.Redirect("~/Planes.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos del Plan", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
            else {
                Response.Write("<script>alert('Ya existe un plan con esas caracteristicas');</script>");

            }
        }

        private bool validar()
        {
            PlanLogic pl = new PlanLogic();

            if ((pl.validaPlanExistente(ViewState["descripcion"].ToString(), Int32.Parse(ViewState["especialidad"].ToString()))))
            {
                return false;
            }
            return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Planes.aspx");
        }    
   }
}