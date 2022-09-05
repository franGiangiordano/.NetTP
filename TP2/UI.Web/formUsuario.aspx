<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formUsuario.aspx.cs" Inherits="UI.Web.formUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<style type="text/css">
.content {
    width: 100%;
    height:auto;
}

.filas {
    font-size: 15px;
    font-weight: bold;
    padding-left: 10px;
    padding-top: 10px;   
    padding-bottom: 10px;
    width: 97%;
    height:100px;
    margin-left: 50%;
}

.left {
    padding-left: 10px;
    padding-top: 10px;
    margin-left: 57px;
    float: left;
    position: relative;
    width: 30%;
    height: auto;
    margin:0px auto;
    text-align:left;
}

.right {
    padding-top: 10px;
    padding-left: 10px;
    margin-left: 10px;
    position: relative;
    float: left;
    width: 30%;
    height: auto;
    text-align:left;
}


</style>

<body>
    <form id="formUsuario" runat="server">
        <div class ="content">
            <div class ="left">
                <div class="filas">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" type="text"></asp:TextBox>
                        <div>
                         
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Nombre no puede estar vacio" ForeColor="Red" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                         <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="El campo Nombre admite solo letras" ForeColor="Red" ControlToValidate="txtNombre" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                        </div> 
                </div>
                <div class="filas">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <div>
                          <!-- validamos que no este vacio-->
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo Email no puede estar vacio" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                          <br />
                          <!-- validar el mail -->
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="El campo Email no es valido" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"></asp:RegularExpressionValidator>
                        </div>
                </div>
                <div class="filas">
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                    <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                        <div>
                          <!-- validamos que no este vacio-->
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo Clave no puede estar vacio" ForeColor="Red" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                          <br />
                          <!-- validamos longitud-->
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="El campo Clave debe tener mas de 7 caracteres" ForeColor="Red" ControlToValidate="txtClave" ValidationExpression="^.{8,150}$"></asp:RegularExpressionValidator>
                        </div>      
                </div>
                <div class="filas">
                    <asp:Label ID="lblLegajo" runat="server" Text="Legajo"></asp:Label>
                    <asp:DropDownList ID="cmbLegajos" runat="server"></asp:DropDownList>
                     <!-- no validamos nada es un combo-->
                </div>
            </div>
            <div class ="right">
                <div class="filas">
                    <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado"></asp:Label>
                    <asp:CheckBox ID="chkHabilitado" runat="server" />
                     <!-- no validamos nada es un checklist--> 
                </div>
                <div class="filas">
                   <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
                   <asp:TextBox ID="txtApellido" runat="server" type="text"></asp:TextBox>
                        <div>
                            <!-- validamos que no este vacio y que sea letras-->
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo Apellido no puede estar vacio" ForeColor="Red" ControlToValidate="txtApellido"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="El campo Apellido admite solo letras" ForeColor="Red" ControlToValidate="txtApellido" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
                        </div>
                </div>
                <div class="filas">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                     <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        <div>
                            <!-- validamos que no este vacio-->
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="El campo Usuario no puede estar vacio" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                        </div>
                </div>
                <div class="filas">
                     <asp:Label ID="lblConfirmarClave" runat="server" Text="Confirmar Clave"></asp:Label>
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
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </form>
</body>
</html>
