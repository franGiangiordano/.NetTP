<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cursos</title>
    <link rel="stylesheet" href="estilos/gridView.css">
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="odsCursos" runat="server" DataObjectTypeName="Business.Entities.Curso" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.CursoAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdCursos" Class="mGrid" runat="server" AutoGenerateColumns="False" DataSourceID="odsCursos" OnRowCommand="grdCursos_RowCommand" Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="DescripcionMateria" HeaderText="Descripcion Materia" SortExpression="Descripcion" />
                <asp:BoundField DataField="DescripcionComision" HeaderText="Descripcion Comision" SortExpression="Descripcion" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" SortExpression="AnioCalendario" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" SortExpression="NombrePlan" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\boton-editar.png" CommandName="Editar" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\borrar.png" CommandName="Borrar" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" />
                <asp:ButtonField ButtonType="Image" ImageUrl="~\Imagenes\buscar.png" CommandName="Docentes" HeaderText="Ver Docentes" ShowHeader="True" Text="Ver Docentes" />
            </Columns>
        </asp:GridView>
         <div>
            <asp:Button ID="btnInsertar" class="btn btn-bootstrap" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
        </div>
    </form>
</body>
</html>
