<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Ingresar
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ingresar</h2>
    <p>
        Ingrese usuario y contraseña. <%= Html.ActionLink("Registrese", "Register") %> si no tiene una cuenta.
    </p>
    <%= Html.ValidationSummary("Usuario o contraseña incorrecto.") %>

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
                    <label for="password">Contraseña:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Recuerdame?</label>
                </p>
                <p>
                    <input type="submit" value="Ingresar" />
                </p>
            </fieldset>
        </div>
      </form>
    <% } %>
</asp:Content>
