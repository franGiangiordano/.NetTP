using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/formUsuario.aspx?modo=alta");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/formUsuario.aspx");
        }

        protected void grdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                //string id = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                //Response.Write(id);

                //grdUsuarios.DataBind();

                //Session["celda"] = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)];

                //Response.Write(grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)]);

                //string pName = grdUsuarios.SelectedRow.Cells[1].Text;
                //Response.Write(pName);
                //Response.Write(grdUsuarios.SelectRow(0).ToString());

                Response.Redirect("~/formUsuario.aspx");

            }
            else if (e.CommandName == "Borrar")
            {
                Response.Redirect("~/formUsuario.aspx");
            }
        }
    }
}