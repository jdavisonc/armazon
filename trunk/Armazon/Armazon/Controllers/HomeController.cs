using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Armazon.Models;
using Armazon.Models.DataTypes;

namespace Armazon.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            List<DTProduct> dtCollection = new List<DTProduct>();
            ConsultaFachada consultaFachada = new ConsultaFachada();
            foreach (Producto prod in consultaFachada.productosMasImportantes().Take(9))
            {
                dtCollection.Add(prod.getDataType());
            }

            int currentPageIndex = id.HasValue ? id.Value - 1 : 0;
            ViewData["Collection"] = dtCollection.ToPagedList(currentPageIndex, 9);
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles="Administrador")]
        public ActionResult AdministratorManager()
        {
            return View();
        }
    }
}
