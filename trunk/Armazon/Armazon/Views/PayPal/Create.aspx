<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.PayPal>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear PayPal
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear PayPal</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Campos</legend>
            
            <p>
                <label for="Usuario">Usuario:</label>
                <%= Html.TextBox("Usuario") %>
                <%= Html.ValidationMessage("Usuario", "*") %>
            </p>
            <p>
                <label for="Password">Password:</label>
                <%= Html.Password("Password") %>
                <%= Html.ValidationMessage("Password", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Volver", "Index") %>
    </div>
    <form method="post" action="https://api-3t.sandbox.paypal.com/nvp">
        <input type="hidden" name="USER" value= "mussio_1242266962_biz_api1.hotmail.com"/>
        <input type="hidden" name="PWD" value= "1242266974"/>
        <input type="hidden" name="SIGNATURE" value= "AiPC9BjkCyDFQXbSkoZcgqH3hpacAWKtVcoSjwXfslWj7lHQAFynLiQG"/>
        <input type="hidden" name="VERSION" value="2.3"/>
        <input type="hidden" name="PAYMENTACTION" value="Authorization"/>
        <input name="AMT" value="10000000"/>
        <input type="hidden" name="RETURNURL" value="http://www.gmail.com"/>
        <input type="hidden" name="CANCELURL" value="http://www.yahoo.com"/>
        <input type="submit" name="METHOD" value="SetExpressCheckout"/>
    </form>    
</asp:Content>

