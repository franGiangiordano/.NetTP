<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="estilos/formLogin.css">
</head>
<body>
  <div class="container">
    <div class="title">¡Bienvenido al Sistema! <br /> Por favor digite su información de Ingreso</div>  
    <div class="content">
      <form id="formLogin" runat="server">
        <div class="user-details">
          <div class="input-box">
           <asp:Label ID="lblUsuario" class="details" runat="server" Text="Usuario"></asp:Label>
           <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox> 
            <div>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo Usuario no puede estar vacio" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
            </div>
          </div>
          <div class="input-box">
            <asp:Label ID="lblClave" class="details" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" type="password"></asp:TextBox> 
              <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo Clave no puede estar vacio" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
              </div>
          </div>
        </div>
        <div class="button">
          <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Aceptar"/>
        </div>
      </form>
    </div>
  </div>
</body>
</html>
