<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Models.DataTypes.DTProduct>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= ViewData["Title"]%></h2>
    <table>
        <tr>
            <td>
                <div id="listado">
                    <%foreach (Armazon.Models.DataTypes.DTProduct p in Model) { %>
                    <div class="fltleft prodItem">
                        <a href="<%= Url.Action("Details", "Producto", new { id = p.Id })%>" title="Go to <%= p.Nombre %> Details Page">
                          <% if ((p.Images.Count > 0) && (p.Tienda == null)){ %>
                            <img src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = p.Id } ) %>" alt="<%=p.Nombre %>"  width="150" height="150"/>
                          <% }else if ((p.Images.Count > 0) && (p.Tienda != null)){ %>
                            <img src="<%= p.Images[0].ImagenURL %>" width="150" height="150"/>
                          <% }else{ %>
                             <img src="/Content/noImageAvailable.jpg" width="150" height="150"/>
                          <% } %>
                          <p>
                          <%=p.Nombre %><br />
                            $ <%=p.Precio.ToString()%>
                          </p>
                        </a>
                    </div>
                    <%} %>
                </div>
            </td>>
        </tr>
        <tr>
            <td>
                <div class="pager">
		            <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount, new { fullText = ViewData["FullText"]})%>
	            </div>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
</asp:Content>