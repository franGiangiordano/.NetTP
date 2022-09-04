﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <h2><%: Title %>.<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Business.Entities.Usuario" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="Data.Database.UsuarioAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowFooter="True" OnRowCommand="grdUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Apellido" SortExpression="Apellido">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NombreUsuario" SortExpression="NombreUsuario">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Habilitado" SortExpression="Habilitado">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Habilitado") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Habilitado") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Button" CommandName="Borrar" HeaderText="Borrar" ShowHeader="True" Text="Borrar" />
                <asp:ButtonField ButtonType="Button" HeaderText="Editar" ShowHeader="True" Text="Editar" CommandName="Editar"/>
            </Columns>
        </asp:GridView>
    </h2>
        </div>
        <p>
            <asp:Button ID="btnInsertar" runat="server" CommandName="Insertar" Text="Insertar" OnClick="btnInsertar_Click" />
        </p>
    </form>
</body>
</html>
