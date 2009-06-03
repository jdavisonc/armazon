<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    CambiarContraseña
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cambiar contraseña</h2>
    <p>
        Utilice el siguiente formulario para cambiar su contraseña. 
    </p>
    <p>
        La contraseña requiere un mínimo de <%=Html.Encode(ViewData["PasswordLength"])%> caracteres de largo.
    </p>
    <%= Html.ValidationSummary("Error al cambiar la contraseña.")%>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Información de la cuenta</legend>
                <p>
                    <label for="currentPassword">Contraseña actual:</label>
                    <%= Html.Password("currentPassword") %>
                    <%= Html.ValidationMessage("currentPassword") %>
                </p>
                <p>
                    <label for="newPassword">Nueva contraseña:</label>
                    <%= Html.Password("newPassword") %>
                    <%= Html.ValidationMessage("newPassword") %>
                </p>
                <p>
                    <label for="confirmPassword">Confirmar nueva contraseña:</label>
                    <%= Html.Password("confirmPassword") %>
                    <%= Html.ValidationMessage("confirmPassword") %>
                </p>
                <p>
                    <input type="submit" value="Cambiar Contraseña" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
