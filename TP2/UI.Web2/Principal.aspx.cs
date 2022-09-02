﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web2
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Write(Session["usuario"]);

        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            bool hasParent = (e.Item.Parent != null);

            switch (hasParent)
            {
                case false:
                    switch (e.Item.Value)
                    {
                        case "Listados":
                            //Response.Redirect("~/RGS/Workflow/Workflow.aspx");
                            break;
                        case "HoursOfBusiness":
                            //Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                            break;
                    }
                    break;
                case true:
                    switch (e.Item.Parent.Value)
                    {
                        case "Listados":
                            switch (e.Item.Value)
                            {
                                case "Usuarios":
                                    Response.Redirect("~/Usuarios.aspx");
                                    break;
                                case "Edit":
                                    Response.Redirect("~/RGS/Workflow/WorkflowEdit.aspx");
                                    break;
                                case "Create":
                                    Response.Redirect("~/RGS/Workflow/WorkflowCreate.aspx");
                                    break;
                                case "Delete":
                                    Response.Redirect("~/RGS/Workflow/WorkflowDelete.aspx");
                                    break;
                            }
                            break;
                        case "HoursOfBusiness":
                            switch (e.Item.Value)
                            {
                                case "Overview":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                                    break;
                                case "Edit":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                                    break;
                                case "Create":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHoursCreate.aspx");
                                    break;
                                case "Delete":
                                    Response.Redirect("~/RGS/Workflow/BusinessHour/BusinessHours.aspx");
                                    break;
                            }
                            break;
                    }
                    break;

            }
        }
    }
}