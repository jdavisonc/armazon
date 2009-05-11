<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Producto Eliminado
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Producto Eliminado</h2>
    <div>
        <p>El producto ha sido eliminada con exito.</p>
    </div>
    <div>
        <p><a href="/Producto">Ver Productos</a></p>
    </div>

</asp:Content>
