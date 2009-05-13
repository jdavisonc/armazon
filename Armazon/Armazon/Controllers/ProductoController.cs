using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using DatabaseAccess;
using Armazon.Controllers.ViewModels;

namespace Armazon.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var productos = administracionFachada.findAllProductos().ToList();
            return View(productos);
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            Producto producto = administracionFachada.getProducto(id);

            DetalleProductoFromVM form = new DetalleProductoFromVM();

            List<Valor> lstValores = new List<Valor>();

            foreach (Valor v in administracionFachada.valoresProductos(id))
            {
                lstValores.Add(v);
            }

            form.setValores(lstValores);
            form.setProducto(producto);

            if (producto == null)
                return View("NotFound");
            else
                return View(form);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Producto/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Producto producto = new Producto();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(producto);
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addProducto(producto);
                administracionFachada.saveProducto();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Producto/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var producto = administracionFachada.getProducto(id);
            return View(producto);
        }

        //
        // POST: /Producto/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                Producto producto = administracionFachada.getProducto(id);
                //producto.ProductoID = Request.Form["ProductoID"];
                administracionFachada.saveProducto();
                return RedirectToAction("Details", new { id = producto.ProductoID });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var producto = administracionFachada.getProducto(id);
            if (producto == null)
                return View("NotFound");
            else
                return View(producto);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var producto = administracionFachada.getProducto(id);
            if (producto == null)
            {
                return View("NotFound");
            }
            administracionFachada.deleteProducto(id);
            administracionFachada.saveProducto();
            return View("Deleted");
        }
    }
}
