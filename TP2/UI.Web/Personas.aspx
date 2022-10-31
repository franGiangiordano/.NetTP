<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Personas</title>
    <link rel="stylesheet" href="estilos/gridView.css">
    <link rel="stylesheet" href="estilos/header.css">
</head>
<body>
    <form id="form1" runat="server">
    <header>
 <nav class="nav__hero">
            <div class="container nav__container">
                <div class="logo">
                    <h2 class="logo__name">Academia<span class="point"> UTN </span></h2>
                </div>
                <div>
                    <asp:ImageButton ID="btnAtras" runat="server" class="botonAtras" ImageUrl="~\Imagenes\atras.png" OnClick="btnAtras_Click"/>
				</div>	 
            </div>
        </nav> 
</header>

    <h1>
        Listado Personas
    </h1>
        <div>
        </div>
        <asp:ObjectDataSource ID="odsPersonas"  runat="server" DataObjectTypeName="Business.Entities.Persona" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.PersonaAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="grdPersonas" Class="mGrid" runat="server" AutoGenerateColumns="False" DataSourceID="odsPersonas" OnRowCommand="grdPersonas_RowCommand" Font-Size="Large">
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
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\boton-editar.png" CommandName="Editar" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\borrar.png" CommandName="Borrar" HeaderText="Borrar" ShowHeader="True" Text="Borrar" />
            </Columns>
        </asp:GridView>
        <div>
            <asp:Button ID="btnInsertar" class="btn btn-bootstrap" runat="server" CommandName="Insertar" Text="Insertar" OnClick="btnInsertar_Click" />
        </div>
    </form>
</body>
</html>
