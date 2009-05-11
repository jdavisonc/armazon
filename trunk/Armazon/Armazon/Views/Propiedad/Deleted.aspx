<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Propiedad Eliminada
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Propiedad Eliminada</h2>
    <div>
        <p>La propiedad ha sido eliminada con exito.</p>
    </div>
    <div>
        <%=Html.ActionLink("Ver Propiedades", "Index")%>
    </div>

</asp:Content>
