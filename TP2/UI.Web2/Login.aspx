<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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
       <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Aceptar"  />
     </div>





    </div>
</asp:Content>
