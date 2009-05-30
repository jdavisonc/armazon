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
            return View(fachada.ventasTotalesXPeriodo(txtFechaInicio, txtFechaFin).ToPagedList<DTCarrito>(currentPageIndex, 10));
        }

        public ActionResult DetalleCarrito(int id, string fechaInicio, string fechaFin, int pagina, int? page)
        {
            AdministracionFachada fachada = new AdministracionFachada();
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            ViewData["txtFechaInicio"] = fechaInicio;
            ViewData["txtFechaFin"] = fechaFin;
            ViewData["pagina"] = pagina;
            return View(fachada.getProductosDeCarrito(id).ToPagedList<DTPedido>(currentPageIndex, 10));
        }

        public ActionResult ReportesXSubCategoria(int? page)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categorias = administracionFachada.findAllCategorias().ToList();

            int currentPageIndex = page.HasValue && page != 0 ? page.Value - 1 : 0;
            ViewData["pagina"] = currentPageIndex;
            return View(categorias.ToPagedList(currentPageIndex,10));
        }

        public ActionResult SeleccionarSubCategoria(int id, int pagina, int? page)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var subCategorias = administracionFachada.findAllSubCategorias(id).ToList();

            int currentPageIndex = page.HasValue && page != 0 ? page.Value - 1 : 0;
            ViewData["IdCategoria"] = id;
            ViewData["pagina"] = pagina;
            return View(subCategorias.ToPagedList(currentPageIndex,10));
        }

		 public ActionResult UsuariosQueMasTaguean()        
         {            
             OperativaFachada fachada = new OperativaFachada();
             List<DTUsuarioTag> usuariosTags = fachada.tagsXUsuario();
             return View(usuariosTags);
         }
        
        public ActionResult ProductosMasVendidos(int id, int idCategoria,int pagina, int? page)
        {
            OperativaFachada operativaFachada = new OperativaFachada();
            IQueryable<Producto> productos = operativaFachada.ProductosMasVendidos(id);
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            ViewData["IdCategoria"] = idCategoria;
            ViewData["pagina"] = pagina;
            return View(productos.ToPagedList(currentPageIndex,10));
        }
    }
}
