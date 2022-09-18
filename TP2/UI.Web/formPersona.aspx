<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formPersona.aspx.cs" Inherits="UI.Web.formPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="estilos/formUsuario.css">

    <title>Formulario Persona</title>
</head>
<body>
    <div class="container">
    <div class="title">Formulario Personas</div>
    <div class="content">
      <form id="formPersona" runat="server">
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
            <asp:Label ID="lblEmail" class="details" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <div>
                    <!-- NO validamos que no este vacio porque es opcional-->
                    
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
            <asp:Label ID="lblDireccion" class="details" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo Direccion no puede estar vacio" ForeColor="Red" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>                
                </div>  
          </div>
          <div class="input-box">
            <asp:Label ID="lblTelefono" class="details" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                <div>
                    <!-- NO validamos que no este vacio porque es opcional-->
  
                    <!-- validamos que sean solo numeros-->
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="El campo Telefono admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtTelefono" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>  
               </div>
          </div>
            <!-- se agrego al cleckbox   AutoPostBack="true"    para poder manejar el evento de checkChanged--> 
          <div class="input-box">
                <asp:Label ID="lblAdmin" class="details" runat="server" Text="Es Administrador"></asp:Label>
                <asp:CheckBox ID="chkAdmin" runat="server" OnCheckedChanged="chkAdmin_CheckedChanged" AutoPostBack="true" />
                <!-- no validamos nada es un checklist--> 
          </div>
          <div class="input-box">
            <asp:Label ID="lblLegajo" class="details" runat="server" Text="Legajo"></asp:Label>
            <asp:TextBox ID="txtLegajo" runat="server" value="1111"></asp:TextBox>
                <div>
                    <!-- validamos que no este vacio-->
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="El campo Legajo no puede estar vacio" ForeColor="Red" ControlToValidate="txtLegajo"></asp:RequiredFieldValidator>
                    <!-- validamos que sean solo numeros mayor a 1-->
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="El campo Legajo tiene que ser entero mayor que 1" ForeColor="Red" ControlToValidate="txtLegajo" ValidationExpression="^([1-9][0-9]+|[2-9])$"></asp:RegularExpressionValidator>  
               </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblPlan" class="details" runat="server" Text="Plan"></asp:Label>
            <asp:DropDownList ID="cmbPlan" runat="server"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
          </div>
          <div class="input-box">
            <asp:Label ID="lblTipo" class="details" runat="server" Text="Tipo"></asp:Label>
            <asp:DropDownList ID="cmbTipo" runat="server">
              </asp:DropDownList>
            <!-- no validamos nada es un combo-->
          </div>
            <div class="input-box">
            <asp:Label ID="lblFecha" class="details" runat="server" Text="Fecha Nacimiento"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" type="date" required pattern="\d{2}-\d{2}-\d{4}" ></asp:TextBox>
          </div>                  
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
