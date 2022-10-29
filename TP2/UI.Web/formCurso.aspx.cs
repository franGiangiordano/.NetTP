using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class formCurso : System.Web.UI.Page
    {
        private Business.Entities.Curso _CursoActual;

        public Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarComboMaterias();
                cargarComboComisiones();
            }
            if (Session["estado"] == null)
            {
                Response.Redirect("~/Cursos.aspx");
            }
            else if (Session["estado"].Equals("modificacion"))
            {
                //Tenemos que guardar en el ViewState los datos ingresados para conservarlos entre postbacks
                CargarViewStates();

                MapearDeDatos();
            }
        }

        private void cargarComboMaterias()
        {
            MateriaLogic ml = new MateriaLogic();
            this.cmbMateria.DataSource = ml.GetAll();
            this.cmbMateria.DataTextField = "Descripcion";
            this.cmbMateria.DataValueField = "ID";
            this.cmbMateria.DataBind();
        }
        private void cargarComboComisiones()
        {
            ComisionLogic ml = new ComisionLogic();
            this.cmbComison.DataSource = ml.GetAll();
            this.cmbComison.DataTextField = "Descripcion";
            this.cmbComison.DataValueField = "ID";
            this.cmbComison.DataBind();
        }

        private void CargarViewStates()
        {
            ViewState["cupo"] = txtCupo.Text;
            ViewState["materia"] = cmbMateria.SelectedValue;
            ViewState["comision"] = cmbComison.SelectedValue;
            ViewState["anioCalendario"] = txtAnioCalendario.Text;
        }

        private void MapearDeDatos()
        {
            CursoLogic cl = new CursoLogic();

            string id = (string)Session["id"];
            CursoActual = new Curso();
            CursoActual = cl.GetOne(Int32.Parse(id));

            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.cmbComison.SelectedValue = this.CursoActual.IDComision.ToString();
            this.cmbMateria.SelectedValue = this.CursoActual.IDMateria.ToString();

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
                    Curso curso = new Curso();
                    CursoActual = curso;
                    CursoActual.AnioCalendario = Int32.Parse(txtAnioCalendario.Text);
                    CursoActual.Cupo = Int32.Parse(txtCupo.Text);
                    CursoActual.IDMateria = Int32.Parse(this.cmbMateria.SelectedValue);
                    CursoActual.IDComision = Int32.Parse(this.cmbComison.SelectedValue);
                    CursoActual.State = Usuario.States.New;
                    break;

                case "modificacion":
                    CursoActual.Cupo = Int32.Parse((string)ViewState["cupo"]);
                    CursoActual.AnioCalendario = Int32.Parse((string)ViewState["anioCalendario"]);
                    CursoActual.IDMateria = Int32.Parse((string)ViewState["materia"]);
                    CursoActual.IDComision = Int32.Parse((string)ViewState["comision"]);
                    CursoActual.State = Usuario.States.Modified;
                    break;
            }
        }

        public void GuardarCambios()
        {
            try
            {
                MapearADatos();
                CursoLogic cl = new CursoLogic();
                cl.Save(CursoActual);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar el curso", Ex);
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
                    Response.Redirect("~/Cursos.aspx");
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al guardar datos del Curso", Ex);
                    Response.Write("<script>alert('" + ExcepcionManejada.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Ya existe un curso con esas caracteristicas');</script>");

            }
        }


        private bool validar()
        {
            CursoLogic pl = new CursoLogic();
            if (Session["estado"].Equals("modificacion"))
            {
                if ((pl.validaCursoExistente(Int32.Parse(ViewState["materia"].ToString()), Int32.Parse(ViewState["comision"].ToString()), Int32.Parse(ViewState["anioCalendario"].ToString()))))
                {
                    return false;
                }
            }
            else
            {
                if (pl.validaCursoExistente(Int32.Parse(cmbMateria.SelectedValue), Int32.Parse(cmbComison.SelectedValue), Int32.Parse(txtAnioCalendario.Text)))
                {
                    return false;
                }
            }

            return true;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("estado");
            Response.Redirect("~/Cursos.aspx");
        }
    }
}