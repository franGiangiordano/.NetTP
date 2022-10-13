<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formInscripcion.aspx.cs" Inherits="UI.Web.formInscripcion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Inscripcion</title>
    <link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
    <div class="container">
    <div class="title">Formulario inscripciones</div>
    <div class="content">
      <form id="formPersona" runat="server">
        <div class="user-details">
          <div class="input-box">
            <asp:Label ID="lblMateria" class="details" runat="server" Text="Materia"></asp:Label>
            <asp:DropDownList ID="cmbMateria" runat="server"></asp:DropDownList>
          </div>          
          <div class="input-box">
            <asp:Label ID="Label1" class="details" runat="server" Text="Comision"></asp:Label>
            <asp:DropDownList ID="cmbComision" runat="server"></asp:DropDownList>
          </div>
          <div class="input-box">
            <asp:Label ID="lblLegajo" class="details" runat="server" Text="Legajo"></asp:Label>
             <asp:DropDownList ID="cmbLegajo" runat="server"></asp:DropDownList>
          </div>
          <div class="input-box">
            <asp:Label ID="lblCondicion" class="details" runat="server" Text="Condicion"></asp:Label>
            <asp:DropDownList ID="cmbCondicion" runat="server">
                <asp:ListItem>Regular</asp:ListItem>
                <asp:ListItem>Aprobado</asp:ListItem>
                <asp:ListItem>Libre</asp:ListItem>
              </asp:DropDownList>
          </div>
            <div class="input-box">
            <asp:Label ID="lblNota" class="details" runat="server" Text="Nota"></asp:Label>
            <asp:TextBox ID="txtNota" runat="server" type="text"></asp:TextBox> 
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo notas admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtNota" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>
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
