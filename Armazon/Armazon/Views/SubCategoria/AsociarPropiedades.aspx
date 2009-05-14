<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.Controllers.ViewModels.AsociarPropiedadesFormVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Asociar Propiedades
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function agregar(){
            //var id = document.getElementById("").value;
            document.getElementById("frmAsociarPropiedades").action = "/SubCategoria/AgregarPropiedades";
            document.getElementById("frmAsociarPropiedades").submit();
        }
        function quitar(){
            //var id = document.getElementById("").value;
            document.getElementById("frmAsociarPropiedades").action = "/SubCategoria/QuitarPropiedades";
            document.getElementById("frmAsociarPropiedades").submit();
        }
    </script>
    <h2>Asociar Propiedades a SubCategorías</h2>
    <form action="" id="frmAsociarPropiedades" method="post">
        <input type="hidden" id="hdnIdSubCategoria" name="hdnIdSubCategoria" value='<%=Model.getSubCategoria().SubCategoriaID %>' />
        <input type="hidden" id="hdn" name="hdn" value='<%=Model.getAsociadas() %>' />
        <p>
            <h4>SubCategoría: <%=Model.getSubCategoria().Nombre %></h4>
        </p>
        <table align="center" border="0">
            <tr>
                <td align="center">Propiedades Disponibles</td>
                <td></td>
                <td align="center">Propiedades Asociadas</td>
            </tr>
            <tr>
                <td rowspan="2">
                    <select id="selDisponibles" name="selDisponibles" multiple="multiple" style="height: 150px; width: 200px">
                    <% foreach (var item in Model.getDisponibles()) { %>
                        <option value='<%=item.PropiedadID%>'><%=item.Nombre%></option>
                    <% } %>
                    </select>
                </td>
                <td>
                    <input type="button" id="btnAgregar" value=">>" onclick="agregar()"/>
                </td>
                <td rowspan="2">
                    <select id="selAsociadas" name="selAsociadas" multiple="multiple" style="height: 150px; width: 200px">
                    <% foreach (var item in Model.getAsociadas()) { %>
                        <option value='<%=item.PropiedadID%>'><%=item.Nombre%></option>
                    <% } %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnQuitar" value="<<" onclick="quitar()"/>
                </td>
            </tr>
        </table>
    </form>
    <%=Html.ActionLink("Confirmar", "ListarSubCategoria", new { id = Model.getSubCategoria().CategoriaID })%>
</asp:Content>
