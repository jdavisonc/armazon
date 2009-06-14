<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Armazon.IPagedList<Armazon.DTCarrito>>" %>
<%@ Import Namespace="Armazon"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	VentasTotalesXPeriodo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ventas Totales  por Período</h2>
    
    <% using (Html.BeginForm())
       {%>
       <div style="position:relative; top:20px">
            <table align="center">
		        <tr>
			        <td>Fecha Inicio:</td>
			        <td><input style="width: 80px" size="8" type="text" id="txtFechaInicio" name="txtFechaInicio" value="<%=ViewData["txtFechaInicio"] %>" readonly></td>
			        <td><img src="../../Content/calendario/img.gif" id="f_trigger_a" style="cursor: pointer; border: 1px solid red;" title="Date selector"
				              onmouseover="this.style.background='red';" onmouseout="this.style.background=''" /></td>
			        <td style="width: 80px"></td>
			        <td>Fecha Fin:</td>
			        <td><input style="width: 80px" size="8" type="text" id="txtFechaFin" name="txtFechaFin" value="<%=ViewData["txtFechaFin"] %>" readonly"></td>
			        <td><img src="../../Content/calendario/img.gif" id="f_trigger_b" style="cursor: pointer; border: 1px solid red;" title="Date selector"
				              onmouseover="this.style.background='red';" onmouseout="this.style.background=''" /></td>
		            <td style="width: 80px"></td>
		            <td><input type="submit" id="btnReporte" name="btnReporte" value="Reporte"></td>
		        </tr>
	        </table>
	   </div>
	    
	<%} %>
	<%if (Model != null){ %>
	    <div style="position: relative; top: 40px;">
	        <hr />
	        <table align="center" style="width:81%">
                <tr>
                    <th>
                        Fecha
                    </th>
                    <th>
                        Total
                    </th>
                    <th style="width:20px"></th>
                </tr>
	        <% foreach (DTCarrito item in Model){ %>
	            <tr>
                    <td>
                        <%=item.Fecha %>
                    </td>
                    <td>
                        <%=item.Total %>
                    </td>
                    <td>
                        <a href="<%= Url.Action("DetalleCarrito", new { id = item.IdCarrito, fechaInicio = ViewData["txtFechaInicio"], fechaFin = ViewData["txtFechaFin"], pagina = ViewData["page"] }) %>">
                            <img src="<%= ResolveUrl("~/Content/detail.png") %>" />
                        </a>
                    </td>
                </tr>
    	    
	        <%} %>
	        <tr>
	            <td colspan=3 align=center>
	                <div class="pager">
	                    <%= Html.Paginado(Model.PageSize, Model.PageNumber, Model.TotalItemCount)%>
                    </div>
	            </td>
	        </tr>
	        </table>
	        
	   </div>
	<%} %>
	
	<script type="text/javascript">
        Calendar.setup({
            inputField     :    "txtFechaInicio",     // id of the input field
            ifFormat       :    "%d/%m/%Y",      // format of the input field
            button         :    "f_trigger_a",  // trigger for the calendar (button ID)
            align          :    "Tl",           // alignment (defaults to "Bl")
            singleClick    :    true
        });
    </script>

    <script type="text/javascript">
        Calendar.setup({
            inputField     :    "txtFechaFin",     // id of the input field
            ifFormat       :    "%d/%m/%Y",      // format of the input field
            button         :    "f_trigger_b",  // trigger for the calendar (button ID)
            align          :    "Tl",           // alignment (defaults to "Bl")
            singleClick    :    true
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="JavaScriptsContent" runat="server">
<link rel="stylesheet" type="text/css" media="all" href="../../Content/calendario/calendar-win2k-cold-1.css" title="win2k-cold-1" />
<script type="text/javascript" src="../../Content/calendario/calendar.js"></script>
<script type="text/javascript" src="../../Content/calendario/lang/calendar-en.js"></script>
<script type="text/javascript" src="../../Content/calendario/calendar-setup.js"></script>

</asp:Content>
