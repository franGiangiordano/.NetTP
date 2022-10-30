<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscripciones.aspx.cs" Inherits="UI.Web.Inscripciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inscripciones</title>
    <link rel="stylesheet" href="estilos/gridView.css">
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <asp:ObjectDataSource ID="odsInscripciones" runat="server" DataObjectTypeName="Business.Entities.AlumnoInscripcion" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAllWeb" TypeName="Data.Database.AlumnoInscripcionAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="odsInscripciones2" runat="server" SelectMethod="GetInscripcionesAlumno2" TypeName="Data.Database.AlumnoInscripcionAdapter">
                 <SelectParameters>
                     <asp:SessionParameter Name="idAlumno" SessionField="idPersona" Type="Int32" />
                 </SelectParameters>
             </asp:ObjectDataSource>
             <asp:ObjectDataSource ID="odsInscripciones3" runat="server" DeleteMethod="Delete" SelectMethod="GetInscripcionesDocente2" TypeName="Data.Database.AlumnoInscripcionAdapter">
                 <DeleteParameters>
                     <asp:Parameter Name="ID" Type="Int32" />
                 </DeleteParameters>
                 <SelectParameters>
                     <asp:SessionParameter Name="idDocente" SessionField="idPersona" Type="Int32" />
                 </SelectParameters>
             </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdInscripciones" Class="mGrid" runat="server" AutoGenerateColumns="False"  OnRowCommand="grdInscripciones_RowCommand" Font-Size="Large">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="NomAlumno" HeaderText="Alumno" SortExpression="Alumno" />
                <asp:BoundField DataField="IDCurso" HeaderText="Curso" SortExpression="Curso" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" SortExpression="Condicion" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" SortExpression="Nota" />
                <asp:BoundField DataField="Anio" HeaderText="Año" SortExpression="Año" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" SortExpression="Materia" />
                <asp:BoundField DataField="Comision" HeaderText="Comision" SortExpression="Comision" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" SortExpression="Especialidad" />
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
