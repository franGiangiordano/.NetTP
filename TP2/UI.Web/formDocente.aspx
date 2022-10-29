<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formDocente.aspx.cs" Inherits="UI.Web.formDocente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Docente</title>
    <link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
    <div class="container">
    <div class="title">Formulario Docentes</div>
    <div class="content">
      <form id="formPersona" runat="server">
        <div class="user-details">
          <div class="input-box">
            <asp:Label ID="lblLegajo" class="details" runat="server" Text="Legajo"></asp:Label>
            <asp:DropDownList ID="cmbLegajo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbLegajo_SelectedIndexChanged"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
            <asp:Label ID="Label1" class="details" runat="server" Text="Nombre y Apellido:"></asp:Label>
            <asp:Label ID="lblNombre" class="details" runat="server" Text=""></asp:Label>

            <asp:Label ID="Label2" class="details" runat="server" Text="Cargo:"></asp:Label>
            <asp:DropDownList ID="cmbCargo" runat="server">
                <asp:ListItem>Ayudante</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
              </asp:DropDownList>
          </div>
        <div class="button">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"  OnClick="btnAceptar_Click"/>
            <!-- para saltar validaciones: CausesValidation="False" UseSubmitBehavior="false" -->
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" UseSubmitBehavior="false"/>
        </div>
      </form>
    </div>
  </div>
</body>
</html>
