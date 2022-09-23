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
    public partial class formMateria : System.Web.UI.Page
    {
        private Business.Entities.Materia _MateriaActual;

        public Materia MateriaActual { get => _MateriaActual; set => _MateriaActual = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarCombo();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Materias.aspx");
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
            MateriaLogic ml = new MateriaLogic();

            string id = (string)Session["id"];
            MateriaActual = new Materia();
            MateriaActual = ml.GetOne(Int32.Parse(id));

            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cmbPlan.SelectedValue = this.MateriaActual.IDPlan.ToString();
          
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
            ViewState["HsSemanales"] = txtHsSemanales.Text;
            ViewState["HsTotales"] = txtHsTotales.Text;
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
                    Materia mat = new Materia();
                    MateriaActual = mat;
                    MateriaActual.Descripcion = txtDescripcion.Text;
                    MateriaActual.HSSemanales = Int32.Parse(txtHsSemanales.Text);
                    MateriaActual.HSTotales = Int32.Parse(txtHsTotales.Text);
                    MateriaActual.IDPlan = Int32.Parse(this.cmbPlan.SelectedValue);
                    MateriaActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    MateriaActual.Descripcion = (string)ViewState["descripcion"];
                    MateriaActual.HSSemanales = Int32.Parse((string)ViewState["HsSemanales"]);
                    MateriaActual.HSTotales = Int32.Parse((string)ViewState["HsTotales"]);
                    MateriaActual.IDPlan = Int32.Parse((string)ViewState["plan"]);
                    MateriaActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                MateriaLogic ml = new MateriaLogic();
                ml.Save(MateriaActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar la materia", Ex);
                throw ExcepcionManejada;

            }
        }

        public bool validar()
        {
            MateriaLogic ml = new MateriaLogic();
            if (Session["estado"].Equals("alta")){
                if (ml.ValidarHs(txtHsSemanales.Text, txtHsTotales.Text).Equals(""))
                {
                    if (!Session["estado"].Equals("baja") && ml.GetMateria(this.txtDescripcion.Text, Int32.Parse(this.cmbPlan.SelectedValue)))
                    {
                        Response.Write("<script>alert('La materia ya existe!');</script>");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                Response.Write("<script>alert('Las horas Totales deben ser mayor que las Semanales');</script>");
                return false;
            }
            else
            {
                if (ml.ValidarHs(ViewState["HsSemanales"].ToString(), ViewState["HsTotales"].ToString()).Equals(""))
                {
                    if (!Session["estado"].Equals("baja") && ml.GetMateria(ViewState["descripcion"].ToString(), Int32.Parse(ViewState["plan"].ToString())))
                    {
                        Response.Write("<script>alert('La materia ya existe!');</script>");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                Response.Write("<script>alert('Las horas Totales deben ser mayor que las Semanales');</script>");
                return false;
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
                    Response.Redirect("~/Materias.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos de la Materia", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Materias.aspx");
        }
    }
}