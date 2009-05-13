<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Sucursal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Borrar Sucursal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>La sucursal ha sido borrada</h2>
    <p>

        
        <%=Html.ActionLink("Ver Sucursales", "Index") %>
    </p>
</asp:Content>
