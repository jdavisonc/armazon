<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Armazon.Models.DataTypes.DTUsuarioTag>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Usuarios Que Mas Taguean
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Usuarios Que Mas Taguean</h2><hr/>
    <div style="position: relative; top: 40px">        
        <table align="center">
            <tr>
                <th>
                    Usuario
                </th>
                <th>
                    Cantidad de Tags
                </th>                
            </tr>
            <%foreach (Armazon.Models.DataTypes.DTUsuarioTag item in Model){%>
            <tr>
                <td>
                    <%=item.Usuario%>
                </td>
                <td>
                    <%=item.CantTags%>
                </td>                
            </tr>
            <%}%>        
        </table>
   </div>
</asp:Content>

