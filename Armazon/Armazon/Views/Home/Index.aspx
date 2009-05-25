<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.Models.DataTypes.DTProduct>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Catálogo de produtos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Catálogo de produtos</h2>
    
    <table>
        <tr>
            <td>
                <div id="listado">
                    <%foreach (Armazon.Models.DataTypes.DTProduct p in Model) { %>
                    <div class="fltleft prodItem">
                        <a href="<%= Url.Action("Details", "Producto", new { id = p.Id })%>" title="Go to <%= p.Nombre %> Details Page">
                          <% if (p.Images.Count > 0){ %>
                            <img src="<%= Url.Action( "ShowFirstThumbnail", "Producto", new { productID = p.Id } ) %>" alt="<%=p.Nombre %>"/>
                          <% }else{ %>
                             <img src="/Content/noImageAvailable.jpg" width="150" height="150"/>
                          <% } %>
                          <p>
                          <%=p.Nombre %><br />
                            <%=p.Precio.ToString("C")%>
                            <% if (Page.User.IsInRole("Administrador")) { %>
                                <br><%= Html.ActionLink("Edit","Edit","Producto", new { id=p.Id, idSubCategoria=p.SubcaterogiaID },null) %>
                            <% } %>
                          </p>
                        </a>
                        
                    </div>
                    <%} %>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="pager">
	                <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount)%>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
