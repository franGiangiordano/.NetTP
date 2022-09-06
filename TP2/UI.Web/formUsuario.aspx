<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formUsuario.aspx.cs" Inherits="UI.Web.formUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Usuario</title>
    <link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
<div class="container">
    <div class="title">Formulario Usuarios</div>
    <div class="content">
      <form id="formUsuario" runat="server">
        <div class="user-details">
          <div class="input-box">
            <asp:Label ID="lblNombre" class="details" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" type="text"></asp:TextBox>
                <div>   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Nombre no puede estar vacio" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El campo Nombre admite solo letras" ForeColor="Red" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                </div> 
          </div>
          <div class="input-box">
                <asp:Label ID="lblHabilitado" class="details" runat="server" Text="Habilitado"></asp:Label>
                <asp:CheckBox ID="chkHabilitado" runat="server" />
                <!-- no validamos nada es un checklist--> 
          </div>
          <div class="input-box">
            <asp:Label ID="lblEmail" class="details" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo Email no puede estar vacio" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                    <br />
                    <!-- validar el mail -->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="El campo Email no es valido" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"></asp:RegularExpressionValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblApellido" class="details" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" type="text"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio y que sea letras-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo Apellido no puede estar vacio" ForeColor="Red" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo Apellido admite solo letras" ForeColor="Red" ControlToValidate="txtApellido" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblClave" class="details" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo Clave no puede estar vacio" ForeColor="Red" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                    <br />
                    <!-- validamos longitud-->
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="El campo Clave debe tener mas de 7 caracteres" ForeColor="Red" ControlToValidate="txtClave" ValidationExpression="^.{8,150}$"></asp:RegularExpressionValidator>
                </div>  
          </div>
          <div class="input-box">
            <asp:Label ID="lblUsuario" class="details" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo Usuario no puede estar vacio" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblLegajo" class="details" runat="server" Text="Legajo"></asp:Label>
            <asp:DropDownList ID="cmbLegajos" runat="server"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
          </div>
          <div class="input-box">
            <asp:Label ID="lblConfirmarClave" class="details" runat="server" Text="Confirmar Clave"></asp:Label>
            <asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El campo Confirmar Clave no puede estar vacio" ForeColor="Red" ControlToValidate="txtConfirmarClave"></asp:RequiredFieldValidator>
                    <!-- validamos longitud-->
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="El campo Clave debe tener mas de 7 caracteres" ForeColor="Red" ControlToValidate="txtConfirmarClave" ValidationExpression="^.{8,150}$"></asp:RegularExpressionValidator>
                    <!-- validamos que las claves coincidan-->
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtClave" ControlToValidate="txtConfirmarClave" ErrorMessage="Las claves no coinciden" ForeColor="Red"></asp:CompareValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Las claves no coinciden" ForeColor="Red" ControlToValidate="txtConfirmarClave"></asp:RequiredFieldValidator>
                </div>
          </div>          
        </div>
        <div class="button">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
        </div>
      </form>
    </div>
  </div>
</body>
</html>
