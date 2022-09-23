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
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            Response.Redirect("~/formPlan.aspx");
        }

        protected void grdPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
               string ide = grdPlanes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                Session["estado"] = "modificacion";
                Session["id"] = ide;
                Response.Redirect("~/formPlan.aspx");
            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdPlanes.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);

                Plan plan = new Plan();
                plan.ID = id;
                plan.State = BusinessEntity.States.Deleted;
                try
                {
                    PlanLogic pl = new PlanLogic();
                    pl.Save(plan);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar el plan", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }
            }
            }
        }
}
