<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Models.DataTypes.DTProduct>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Catálogo de produtos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Catálogo de produtos</h2>
    
    <%Html.RenderPartial("ListadoComun"); %>
    
</asp:Content>
