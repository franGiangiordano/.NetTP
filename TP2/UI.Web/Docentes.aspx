<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Docentes.aspx.cs" Inherits="UI.Web.Docentes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Docentes</title>
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
        Listado Docentes
    </h1>
        <div>
            <asp:ObjectDataSource ID="odsDocentes" runat="server" DeleteMethod="Delete" SelectMethod="GetDocentesCurso" TypeName="Data.Database.DocenteCursoAdapter">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="idCurso" SessionField="id" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdDocentes" Class="mGrid" runat="server" AutoGenerateColumns="False" DataSourceID="odsDocentes" OnRowCommand="grdDocentes_RowCommand" Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" SortExpression="Legajo" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\boton-editar.png" CommandName="Editar" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\borrar.png" CommandName="Borrar" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" />
            </Columns>
        </asp:GridView>
         <div>
            <asp:Button ID="btnInsertar" class="btn btn-bootstrap" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
        </div>
    </form>
</body>

</html>
