<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="UI.Web.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
    <Items>
        <asp:MenuItem Text="Listados" Value="Listados">
            <asp:MenuItem Text="Usuarios" />
            <asp:MenuItem Text="Edit" />
            <asp:MenuItem Text="Create" />
            <asp:MenuItem Text="Delete" />
        </asp:MenuItem>
        <asp:MenuItem Text="HoursOfBusiness">
            <asp:MenuItem Text="Overview" />
            <asp:MenuItem Text="Edit" />
            <asp:MenuItem Text="Create" />
            <asp:MenuItem Text="Delete" />
        </asp:MenuItem>
    </Items>
</asp:Menu>
        </div>
    </form>
</body>
</html>
