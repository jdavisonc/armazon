<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Perfil
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Mi Perfil</h2>
    <div style="float:left"><img src="<%= ResolveUrl("~/Content/User.png") %>" style="margin:20px;margin-right:30px" /></div>
    <b>Usuario :</b> <%= Html.Encode(Page.User.Identity.Name) %>
    <br>
    <% if (Page.User.IsInRole("Administrador"))
       { %>
            <b>Soy un ADMINISTRADOR!!</b><br>
    <% } %>
    <br><br>
    <a href="ChangePassword"><img src="<%= ResolveUrl("~/Content/btn_cambiar_pass.png") %>"/></a>
    <a href="/CarrosVendidos/Index"><img src="<%= ResolveUrl("~/Content/btn_historial_compras.png") %>"/></a>
    
</asp:Content>
