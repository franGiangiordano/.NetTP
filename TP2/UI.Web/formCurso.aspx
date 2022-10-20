<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formCurso.aspx.cs" Inherits="UI.Web.formCurso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Curso</title>
    <link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
    <div class="container">
    <div class="title">Formulario Materias</div>
    <div class="content">
      <form id="formPersona" runat="server">
        <div class="user-details">    
          <div class="input-box">
            <asp:Label ID="lblAnioCalendario" class="details" runat="server" Text="Año calendario"></asp:Label>
            <asp:TextBox ID="txtAnioCalendario" runat="server"></asp:TextBox>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo Año calendario no puede estar vacio" ForeColor="Red" ControlToValidate="txtAnioCalendario"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El campo Año Calendario admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtAnioCalendario" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblPlan" class="details" runat="server" Text="Materia"></asp:Label>
            <asp:DropDownList ID="cmbMateria" runat="server"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
          </div>
          <div class="input-box">
            <asp:Label ID="Label1" class="details" runat="server" Text="Comison"></asp:Label>
            <asp:DropDownList ID="cmbComison" runat="server"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
          </div>
          <div class="input-box">
            <asp:Label ID="Label2" class="details" runat="server" Text="Cupo"></asp:Label>
            <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Cupo no puede estar vacio" ForeColor="Red" ControlToValidate="txtCupo"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo Cupo admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtCupo" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>
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
