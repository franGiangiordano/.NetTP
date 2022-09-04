<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
        <h1>     ¡Bienvenido al Sistema!  
Por favor digite su información de Ingreso</h1>
    </div>

     <div class="jumbotron">
           Usuario: <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>         
     </div>

    <div class="jumbotron">
           Contraseña: <asp:TextBox ID="txtPassword" runat="server" type="password"></asp:TextBox>   
        
    <div class="jumbotron">
       <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Aceptar"/>
     </div>
    </div>
    </form>
</body>
</html>
