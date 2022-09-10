<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="UI.Web.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu Principal</title>
	    <link rel="stylesheet" href="estilos/menuPrincipal.css">
</head>
<body>
    <form id="form1" runat="server">
<%--        <div>
            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
    <Items>
        <asp:MenuItem Text="Listados" Value="Listados">
            <asp:MenuItem Text="Usuarios" />
            <asp:MenuItem Text="Edit" />
            <asp:MenuItem Text="Create" />
            <asp:MenuItem Text="Delete" />
        </asp:MenuItem>
        <asp:MenuItem Text="HoursOfBusiness">
            <asp:MenuItem Text="Overview" />
            <asp:MenuItem Text="Edit" />
            <asp:MenuItem Text="Create" />
            <asp:MenuItem Text="Delete" />
        </asp:MenuItem>
    </Items>
</asp:Menu>
        </div>--%>
	<header>
		<nav class="navegacion">
			<ul class="menu">
				<li>
                    <asp:LinkButton ID="LinkButton3" runat="server">Listados</asp:LinkButton>
					<ul class="submenu">
						<li>
                            <asp:LinkButton ID="LinkButtonUsuarios" runat="server" OnClick="LinkButtonUsuarios_Click">Usuarios</asp:LinkButton>
						</li>
						<li>
                            <asp:LinkButton ID="LinkButtonCursos" runat="server">Cursos</asp:LinkButton>
						</li>
						<li>
                            <asp:LinkButton ID="LinkButtonPlanes" runat="server">Planes</asp:LinkButton>
						</li>
                        <li>
                            <asp:LinkButton ID="LinkButtonPersonas" runat="server">Personas</asp:LinkButton>
						</li>
                        <li>
                            <asp:LinkButton ID="LinkButtonMaterias" runat="server">Materias</asp:LinkButton>
						</li>
                        <li>
                            <asp:LinkButton ID="LinkButtonEspecialidades" runat="server">Especialidades</asp:LinkButton>
						</li>
                        <li>
                            <asp:LinkButton ID="LinkButtonComisiones" runat="server">Comisiones</asp:LinkButton>
						</li>
					</ul>
				</li>
				<li>
                    <asp:LinkButton ID="LinkButton2" runat="server">Inscripciones</asp:LinkButton>
				</li>
				<li>
                    <asp:LinkButton ID="LinkButton1" runat="server">Reportes</asp:LinkButton>
				</li>
			</ul>
		</nav>
	</header>
    </form>
</body>
</html>
