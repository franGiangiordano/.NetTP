﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Materias</title>
    <link rel="stylesheet" href="estilos/gridView.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="odsMaterias" runat="server" DataObjectTypeName="Business.Entities.Materia" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.MateriaAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdMaterias" Class="mGrid" runat="server" AutoGenerateColumns="False" DataSourceID="odsMaterias" OnRowCommand="grdMaterias_RowCommand" Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales" SortExpression="Horas Semanales" />
                <asp:BoundField DataField="NombrePlan" HeaderText="NombrePlan" SortExpression="NombrePlan" />
                <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales" SortExpression="Horas Totales" />
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