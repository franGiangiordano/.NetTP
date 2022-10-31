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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Session["estado"] = "alta";            
            //Response.Redirect("~/formUsuario.aspx?modo=alta");            
            Response.Redirect("~/formUsuario.aspx");
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
                string ide = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                
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
                Response.Redirect("~/formUsuario.aspx");
                

            }
            else if (e.CommandName == "Borrar")
            {
                string ide = grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
                int id = Int32.Parse(ide);
                


                //int id = int.Parse(grdUsuarios.DataKeys[index].Value.ToString());
                //int id = Int32.Parse(grdUsuarios.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString());


                Usuario usu = new Usuario();
                usu.ID = id;
                usu.State = BusinessEntity.States.Deleted;
                try
                {                                        
                    ModuloUsuarioLogic mul = new ModuloUsuarioLogic();                    
                    UsuarioLogic ul = new UsuarioLogic();
                    mul.EliminarPermisos(id);                   
                    ul.Save(usu);
                    Response.Redirect(Request.Url.ToString());

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al eliminar permisos", Ex);
                    Response.Write("<script>alert(" + ExcepcionManejada.Message + ");</script>");                    
                }
               

                //Response.Redirect("~/Principal.aspx");
            }
        }

        protected void grdUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnAtras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Principal.aspx");
        }
    }
}