<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formEspecialidad.aspx.cs" Inherits="UI.Web.formEspecialidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Formulario Especialidad</title>
<link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
    <div class="container">
    <div class="title">Formulario Especialidades</div>
    <div class="content">
      <form id="formEspecialidad" runat="server">
        <div class="user-details">
          <div class="input-box">
            <asp:Label ID="lblDescripcion" class="details" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" type="text"></asp:TextBox>
                <div>   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Descripcion no puede estar vacio" ForeColor="Red" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                     <br />
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo Descripcion admite solo letras" ForeColor="Red" ControlToValidate="txtDescripcion" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                </div> 
          </div>
          <div class="input-box">
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
