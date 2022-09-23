<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ObjectDataSource ID="odsPersonas" runat="server" DataObjectTypeName="Business.Entities.Persona" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.PersonaAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="grdPersonas" runat="server" AutoGenerateColumns="False" DataSourceID="odsPersonas" OnRowCommand="grdPersonas_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
               
                <asp:BoundField DataField="DescPlan" HeaderText="DescPlan" SortExpression="DescPlan" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Borrar" HeaderText="Borrar" ShowHeader="True" Text="Borrar" />
            </Columns>
        </asp:GridView>
        <div>
            <asp:Button ID="btnInsertar" class="btn btn-bootstrap" runat="server" CommandName="Insertar" Text="Insertar" OnClick="btnInsertar_Click" />
        </div>
    </form>
</body>
</html>
