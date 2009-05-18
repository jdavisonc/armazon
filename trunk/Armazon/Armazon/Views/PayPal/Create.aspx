<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.PayPal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear PayPal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Compra PayPal</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
        <input type="hidden" id="hdnMonto" name="hdnMonto" value="<%=ViewData["txtMonto"] %>"/>
        <fieldset>
            <legend>Compra</legend>
            
            <p>
                <label> Monto de compra: <%=ViewData["txtMonto"] %></label>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Volver", "Index") %>
    </div>
     
    </asp:Content>

