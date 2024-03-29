﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Especialidades</title>
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
        Listado Especialidades
    </h1>
        <div>
            <asp:ObjectDataSource ID="odsEspecialidades" runat="server" DataObjectTypeName="Business.Entities.Especialidad" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.EspecialidadAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdEspecialidades" Class="mGrid" runat="server" AutoGenerateColumns="False" DataSourceID="odsEspecialidades" OnRowCommand="grdEspecialidades_RowCommand" Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
