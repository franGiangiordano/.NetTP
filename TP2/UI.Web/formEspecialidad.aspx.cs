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
    public partial class formEspecialidad : System.Web.UI.Page
    {
        private Business.Entities.Especialidad _EspecialidadActual;

        public Especialidad EspecialidadActual { get => _EspecialidadActual; set => _EspecialidadActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

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

            string id = (string)Session["id"];
            EspecialidadActual = new Especialidad();
            EspecialidadActual = el.GetOne(Int32.Parse(id));

            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;

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
                    Especialidad esp = new Especialidad();
                    EspecialidadActual = esp;
                    EspecialidadActual.Descripcion = txtDescripcion.Text;
                    EspecialidadActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    EspecialidadActual.Descripcion = (string)ViewState["descripcion"];
                    EspecialidadActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                EspecialidadLogic el = new EspecialidadLogic();
                el.Save(EspecialidadActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la especialidad", Ex);
                throw ExcepcionManejada;

            }
        }

        private void CargarViewStates()
        {
            ViewState["descripcion"] = txtDescripcion.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                try
                {
                    GuardarCambios();
                    Session.Remove("estado"); //cerramos una sesion en particular
                    Response.Redirect("~/Especialidades.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos de la especialidad", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Ya existe una especialidad con esas caracteristicas');</script>");

            }
        }

        private bool validar()
        {
            EspecialidadLogic el = new EspecialidadLogic();

            if (!Session["estado"].ToString().Equals("Baja") && el.GetEspecialidad(this.txtDescripcion.Text))
            {
                return false;
            }
            return true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Especialidades.aspx");
        }
    }
}