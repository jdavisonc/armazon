<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTUsuarioTag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Usuarios Que Mas Taguean
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista de Usuarios Que Mas Taguean</h2>

    <br>
    <table>
        <%foreach (Armazon.Models.DataTypes.DTUsuarioTag item in Model) {%>
            <tr>
                <%=item.Usuario%> | <%=item.CantTags%><br>
            </tr>    
        <%}%>
    </table>

</asp:Content>

