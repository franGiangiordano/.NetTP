using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Globalization;

namespace UI.Web
{
    public partial class formPersona : System.Web.UI.Page
    {
        private Business.Entities.Persona _PersonaActual; 

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCombos();
            }

            if (Session["estado"] == null)
            {
                Response.Redirect("~/Personas.aspx");
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
            PersonaLogic perl = new PersonaLogic();

            string id = (string)Session["id"];
            PersonaActual = new Persona();
            PersonaActual = perl.GetOne(Int32.Parse(id));

            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();

          
            this.cmbPlan.SelectedValue = this.PersonaActual.IDPlan.ToString();
            this.txtFecha.Text = this.PersonaActual.FechaNacimiento.ToString("yyyy-MM-dd"); //ver formato

            if (!Page.IsPostBack) {
                if (this.PersonaActual.Tipo.ToString().Equals("Administrativo"))
                {
                    this.chkAdmin.Checked = true;
                    this.cmbTipo.Enabled = false;
                    this.cmbPlan.Enabled = false;
                    this.txtLegajo.Enabled = false;
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
            ViewState["nombre"] = txtNombre.Text;
            ViewState["apellido"] = txtApellido.Text;
            ViewState["direccion"] = txtDireccion.Text;
            ViewState["telefono"] = txtTelefono.Text;
            ViewState["email"] = txtEmail.Text;
            ViewState["fecha"] = txtFecha.Text;
            ViewState["administrador"] = chkAdmin.Checked;
            ViewState["legajo"] = txtLegajo.Text;
            ViewState["plan"] = cmbPlan.SelectedValue;
            ViewState["tipo"] = cmbTipo.SelectedValue;
        }

        private void cargarCombos()
        {
            PlanLogic pl = new PlanLogic();
            PersonaLogic perl = new PersonaLogic();


            this.cmbPlan.DataSource = pl.GetAll();
            this.cmbPlan.DataTextField = "Descripcion";
            this.cmbPlan.DataValueField = "ID";
            this.cmbPlan.DataBind();

            this.cmbTipo.Items.Add("Alumno");
            this.cmbTipo.Items.Add("Docente");

            this.cmbTipo.SelectedIndex = 1;

        }

        public void MapearADatos()
        {
            PersonaLogic pl = new PersonaLogic();

            switch (Session["estado"])
            {
                case "alta":
                    Persona per = new Persona();
                    PersonaActual = per;
                    PersonaActual.Nombre = txtNombre.Text;
                    PersonaActual.Email = txtEmail.Text;
                    PersonaActual.Direccion = txtDireccion.Text;
                    PersonaActual.Telefono = txtTelefono.Text;
                    PersonaActual.Apellido = txtApellido.Text;

                    if (this.chkAdmin.Checked)
                    {
                        PersonaActual.Legajo = 1;
                        PersonaActual.IDPlan = 2;
                        PersonaActual.Tipo = Persona.TipoPersonas.Administrativo;
                    }
                    else
                    {
                        PersonaActual.Legajo = Int32.Parse(txtLegajo.Text);
                        PersonaActual.IDPlan = Int32.Parse(this.cmbPlan.SelectedValue);
                        PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), cmbTipo.SelectedItem.ToString());
                    }

                    //DateTime FechaNacimiento = Convert.ToDateTime(txtFecha.Text);

                    //txtFecha.Text = FechaNacimiento.ToString("MM/dd/yyyy");

                    //PersonaActual.FechaNacimiento = DateTime.Parse(txtFecha.Text);

                    PersonaActual.FechaNacimiento = DateTime.Parse(Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy"));
                    PersonaActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    PersonaActual.Nombre = (string)ViewState["nombre"];
                    PersonaActual.Email = (string)ViewState["email"];
                    PersonaActual.Apellido = (string)ViewState["apellido"];
                    PersonaActual.Direccion = (string)ViewState["direccion"];
                    PersonaActual.Telefono = (string)ViewState["telefono"];
                    PersonaActual.FechaNacimiento = DateTime.Parse(Convert.ToDateTime(txtFecha.Text).ToString("dd/MM/yyyy"));
                    if (this.chkAdmin.Checked)
                    {
                        PersonaActual.Legajo = 1;
                        PersonaActual.IDPlan = 2;
                        PersonaActual.Tipo = Persona.TipoPersonas.Administrativo;
                    }
                    else
                    {
                        PersonaActual.Legajo = Int32.Parse((string)ViewState["legajo"]);
                        PersonaActual.IDPlan = Int32.Parse((string)ViewState["plan"]);
                        PersonaActual.Tipo = (Persona.TipoPersonas)Enum.Parse(typeof(Persona.TipoPersonas), (string)ViewState["tipo"]);
                    }
                    PersonaActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                PersonaLogic pl = new PersonaLogic();
                pl.Save(PersonaActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la persona", Ex);
                throw ExcepcionManejada;

            }
        }

        public bool Validar()
        {
            PersonaLogic pl = new PersonaLogic();
            //Validamos si la persona existe
            if (this.txtLegajo.Enabled)
            {
                if ( !this.txtLegajo.Text.Equals("1") && pl.GetPersona(Int32.Parse(this.txtLegajo.Text)))
                {
                    return false;
                }
             
            }
            return true;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Personas.aspx");
        }

        protected void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            //no anda para modificar un alumno y un docente 
            if (this.chkAdmin.Checked)
            {
                this.cmbTipo.Enabled = false;
                this.cmbPlan.Enabled = false;
                this.txtLegajo.Enabled = false;
            }
            else
            {
                this.cmbTipo.Enabled = true;
                this.cmbPlan.Enabled = true;
                this.txtLegajo.Enabled = true;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    GuardarCambios();
                    Session.Remove("estado"); //cerramos una sesion en particular
                    Response.Redirect("~/Personas.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos de la persona", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
            else {
                Response.Write("<script>alert('La persona ya existe');</script>");
            }
        }
    }
}