<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="UI.Web2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

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

    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>


</asp:Content>
