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
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.ID
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";
            Response.Redirect("~/formPersona.aspx");
        }

        protected void grdPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string arg = Convert.ToString(((System.Web.UI.WebControls.CommandEventArgs)(e)).CommandArgument);

            if (e.CommandName == "Editar")
            {
                string ide = grdPersonas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

                //string id = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                //Response.Write(id);

                //grdUsuarios.DataBind();

                //Session["celda"] = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)];

                //Response.Write(grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)]);

                //string pName = grdUsuarios.SelectedRow.Cells[1].Text;
                //Response.Write(pName);
                //Response.Write(grdUsuarios.SelectRow(0).ToString());

                Session["estado"] = "modificacion";
                Session["id"] = ide;
                Response.Redirect("~/formPersona.aspx");


            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdPersonas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);



                //int id = int.Parse(grdUsuarios.DataKeys[index].Value.ToString());
                //int id = Int32.Parse(grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString());


                Persona per = new Persona();
                per.ID = id;
                per.State = BusinessEntity.States.Deleted;
                try
                {                   
                    PersonaLogic ul = new PersonaLogic();
                    ul.Save(per);                   
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");
                }


                //Response.Redirect("~/Principal.aspx");
            }
        }

    }
}