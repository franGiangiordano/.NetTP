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
    public partial class formComision : System.Web.UI.Page
    {
        private Business.Entities.Comision _ComisionActual;
        public Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCombo();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Comisiones.aspx");
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
            PlanLogic pl = new PlanLogic();
            ComisionLogic cl = new ComisionLogic();

            string id = (string)Session["id"];
            ComisionActual = new Comision();
            ComisionActual = cl.GetOne(Int32.Parse(id));

            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioCalendario.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cmbPlan.SelectedValue = this.ComisionActual.IDPlan.ToString();

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
            ViewState["descripcion"] = txtDescripcion.Text;
            ViewState["AnioCalendario"] = txtAnioCalendario.Text;
            ViewState["plan"] = cmbPlan.SelectedValue;
        }

        public void cargarCombo()
        {
            PlanLogic pl = new PlanLogic();
            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.DataTextField = "Descripcion";
            this.cmbPlan.DataValueField = "ID";
            this.cmbPlan.DataBind();
        }

        public void MapearADatos()
        {
            switch (Session["estado"])
            {
                case "alta":
                    Comision com = new Comision();
                    ComisionActual = com;
                    ComisionActual.Descripcion = txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(txtAnioCalendario.Text);
                    ComisionActual.IDPlan = Int32.Parse(this.cmbPlan.SelectedValue);
                    ComisionActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    ComisionActual.Descripcion = (string)ViewState["descripcion"];
                    ComisionActual.AnioEspecialidad = Int32.Parse((string)ViewState["AnioCalendario"]);
                    ComisionActual.IDPlan = Int32.Parse((string)ViewState["plan"]);
                    ComisionActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                ComisionLogic cl = new ComisionLogic();
                cl.Save(ComisionActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la comision", Ex);
                throw ExcepcionManejada;

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
                    Response.Redirect("~/Comisiones.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos de la Comision", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Comisiones.aspx");
        }

        public bool validar()
        {
            //falta hacer
            return true;
        }
    }
}