<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Registrar
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear nueva cuenta</h2>
    <p>
        Utilice el siguiente formulario para crear una cuenta. 
    </p>
    <p>
        La contraseña requiere un mínimo de <%=Html.Encode(ViewData["PasswordLength"])%> caracteres de largo.
    </p>
    <%= Html.ValidationSummary("Error al registrar la nueva cuenta.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Información de la cuenta</legend>
                <p>
                    <label for="username">Usuario:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="email">Email:</label>
                    <%= Html.TextBox("email") %>
                    <%= Html.ValidationMessage("email") %>
                </p>
                <p>
                    <label for="password">Contraseña:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <label for="confirmPassword">Confirmar contraseña:</label>
                    <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                <p>
                    <input type="image" src="<%= ResolveUrl("~/Content/btn_registrar.png") %>" value="submit" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
