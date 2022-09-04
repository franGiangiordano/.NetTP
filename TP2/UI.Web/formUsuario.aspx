<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formUsuario.aspx.cs" Inherits="UI.Web.formUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="tabla">
            <div class ="fila">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

                <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
                <asp:CheckBox ID="chkHabilitado" runat="server" />
            </div>
            <div class ="fila">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

                 <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            </div>
            <div class ="fila">
                <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>

                 <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </div>
            <div class ="fila">
                <asp:Label ID="lblLegajo" runat="server" Text="Legajo"></asp:Label>
                <asp:DropDownList ID="cmbLegajos" runat="server"></asp:DropDownList>

                 <asp:Label ID="lblConfirmarClave" runat="server" Text="Confirmar Clave"></asp:Label>
                <asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox>
            </div>
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </form>
</body>
</html>
