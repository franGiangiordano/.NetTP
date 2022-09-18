<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formMateria.aspx.cs" Inherits="UI.Web.formMateria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario Materia</title>
    <link rel="stylesheet" href="estilos/formUsuario.css">
</head>
<body>
    <div class="container">
    <div class="title">Formulario Materias</div>
    <div class="content">
      <form id="formPersona" runat="server">
        <div class="user-details">
          <div class="input-box">
            <asp:Label ID="lblDescripcion" class="details" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" type="text"></asp:TextBox>
                <div>   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Descripcion no puede estar vacio" ForeColor="Red" ControlToValidate="txtDescripcion"></asp:RequiredFieldValidator>
                </div> 
          </div>          
          <div class="input-box">
            <asp:Label ID="lblHSSemanales" class="details" runat="server" Text="Horas Semanales"></asp:Label>
            <asp:TextBox ID="txtHsSemanales" runat="server"></asp:TextBox>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo Horas Semanales no puede estar vacio" ForeColor="Red" ControlToValidate="txtHsSemanales"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El campo Horas Semanales admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtHsSemanales" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblHsTotales" class="details" runat="server" Text="Horas Totales"></asp:Label>
            <asp:TextBox ID="txtHsTotales" runat="server"></asp:TextBox>
                <div>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo Horas Totales no puede estar vacio" ForeColor="Red" ControlToValidate="txtHsSemanales"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo Horas Totales admite numeros mayores a 0" ForeColor="Red" ControlToValidate="txtHsTotales" ValidationExpression="^([1-9][0-9]+|[1-9])$"></asp:RegularExpressionValidator>
                </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblPlan" class="details" runat="server" Text="Plan"></asp:Label>
            <asp:DropDownList ID="cmbPlan" runat="server"></asp:DropDownList>
            <!-- no validamos nada es un combo-->
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
