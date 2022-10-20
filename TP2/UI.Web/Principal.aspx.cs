using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Response.Write(Session["usuario"]);

        }

        //este metodo es para redireccionar enlaces, LinkButton es similar a <a> de HTML
        protected void LinkButtonUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

        protected void LinkButtonPersonas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personas.aspx");

        }

        protected void LinkButtonEspecialidades_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Especialidades.aspx");

        }
        protected void LinkButtonCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");

        }
        
        protected void LinkButtonMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");

        }

        protected void LinkButtonPlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Planes.aspx");

        }

        protected void LinkButtonComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");

        }

        protected void LinkButtonInscripciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inscripciones.aspx");

        }

        //protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        //{
        //    bool hasParent = (e.Item.Parent != null);

        //    switch (hasParent)
        //    {
        //        case false:
        //            switch (e.Item.Value)
        //            {
        //                case "Listados":
        //                    //Response.Redirect("~/RGS/Workflow/Workflow.aspx");
        //                    break;
        //                case "HoursOfBusiness":
        //                    //Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
        //                    break;
        //            }
        //            break;
        //        case true:
        //            switch (e.Item.Parent.Value)
        //            {
        //                case "Listados":
        //                    switch (e.Item.Value)
        //                    {
        //                        case "Usuarios":
        //                            Response.Redirect("~/Usuarios.aspx");
        //                            break;
        //                        case "Edit":
        //                            Response.Redirect("~/RGS/Workflow/WorkflowEdit.aspx");
        //                            break;
        //                        case "Create":
        //                            Response.Redirect("~/RGS/Workflow/WorkflowCreate.aspx");
        //                            break;
        //                        case "Delete":
        //                            Response.Redirect("~/RGS/Workflow/WorkflowDelete.aspx");
        //                            break;
        //                    }
        //                    break;
        //                case "HoursOfBusiness":
        //                    switch (e.Item.Value)
        //                    {
        //                        case "Overview":
        //                            Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
        //                            break;
        //                        case "Edit":
        //                            Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
        //                            break;
        //                        case "Create":
        //                            Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHoursCreate.aspx");
        //                            break;
        //                        case "Delete":
        //                            Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
        //                            break;
        //                    }
        //                    break;
        //            }
        //            break;

        //    }
        //}
    }
}