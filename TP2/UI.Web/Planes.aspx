<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="odsPlanes" runat="server" DataObjectTypeName="Business.Entities.Plan" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.PlanAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <asp:GridView ID="grdPlanes" runat="server" AutoGenerateColumns="False" DataSourceID="odsPlanes" OnRowCommand="grdPlanes_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" SortExpression="Especialidad" />
                <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                <asp:ButtonField ButtonType="Button" CommandName="Borrar" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" />
            </Columns>
        </asp:GridView>
         <div>
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
        </div>
    </form>
</body>
</html>
