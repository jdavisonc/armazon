<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profile
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Profile</h2>
    
    <b>Usuario :</b> <%= Html.Encode(Model.Nombre) %>
    <br>
    <% if (Model.Administrador)
       { %>
            <b>Soy un ADMINISTRADOR!!</b><br>
    <% } %>
    <br><br>
    <%= Html.ActionLink("Cambiar Contrasena", "ChangePassword")%>

</asp:Content>
