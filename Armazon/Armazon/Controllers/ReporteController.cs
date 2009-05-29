using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models.Fachada.Operativa;
using Armazon.Models;
using Armazon.Models.DataTypes;

namespace Armazon
{
    public class ReporteController : Controller
    {

        public ActionResult VentasTotalesXPeriodo()
        {
            ViewData["txtFechaInicio"] = "";
            ViewData["txtFechaFin"] = "";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult VentasTotalesXPeriodo(DateTime txtFechaInicio, DateTime txtFechaFin, int? page)
        {
            OperativaFachada fachada = new OperativaFachada();

            int currentPageIndex = page.HasValue && page!=0 ? page.Value - 1 : 0;
            ViewData["txtFechaInicio"] = Request.Form["txtFechaInicio"];
            ViewData["txtFechaFin"] = Request.Form["txtFechaFin"];
            ViewData["page"] = currentPageIndex;
            return View(fachada.ventasTotalesXPeriodo(txtFechaInicio, txtFechaFin).ToPagedList<DTCarrito>(currentPageIndex, 9));
        }

        public ActionResult DetalleCarrito(int id, string fechaInicio, string fechaFin, int pagina, int? page)
        {
            AdministracionFachada fachada = new AdministracionFachada();
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            ViewData["txtFechaInicio"] = fechaInicio;
            ViewData["txtFechaFin"] = fechaFin;
            ViewData["pagina"] = pagina;
            return View(fachada.getProductosDeCarrito(id).ToPagedList<DTPedido>(currentPageIndex, 9));
        }

        public ActionResult ReportesXSubCategoria()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categorias = administracionFachada.findAllCategorias().ToList();

            return View(categorias);
        }

        public ActionResult SeleccionarSubCategoria(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var subCategorias = administracionFachada.findAllSubCategorias(id).ToList();
            
            return View(subCategorias);
        }

        public ActionResult UsuariosQueMasTaguean()
        {
            OperativaFachada fachada = new OperativaFachada();
            List<DTUsuarioTag> usuariosTags = fachada.tagsXUsuario();
            return View(usuariosTags);
        }
    }
}
