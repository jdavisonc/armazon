<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTPedido>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            
            <th>
                Nombre
            </th>
            <th>
                Cant
            </th>
            
            <th>
                Precio
            </th>
        </tr>

    <%  int i = 0;
        foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {  id=i }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=i })%>
                <%i++; %>
            </td>
            <td>
                <%= Html.Encode(item.Nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.Cant) %>
            </td>
            
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Precio)) %>
            </td>
        </tr>
        
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>

