using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using DatabaseAccess;

namespace Armazon.Controllers
{
    public class TiendaController : Controller
    {
        // GET: /Tienda/
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var tiendas = administracionFachada.findAllTiendas().ToList();
            return View(tiendas);
        }

        // GET: /Tienda/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            Tienda tienda = administracionFachada.getTienda(id);
            if (tienda == null)
                return View("NotFound");
            else
                return View(tienda);
        }
        
        // GET: /Tienda/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: /Tienda/Create
        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles = "Administrador")]
        public ActionResult Create(FormCollection collection)
        {
            Tienda tienda = new Tienda();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(tienda);
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addTienda(tienda);
                administracionFachada.saveTienda();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Tienda/Edit/5 
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var tienda = administracionFachada.getTienda(id);
            return View(tienda);
        }

        // POST: /Tienda/Edit/5
        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AdministracionFachada administracionFachada = new AdministracionFachada();
                Tienda tienda = administracionFachada.getTienda(id);
                tienda.Nombre = Request.Form["Nombre"];
                tienda.Url = Request.Form["Url"];
                tienda.TipoAPI = Request.Form["TipoAPI"];
                return RedirectToAction("Details",new{id=tienda.TiendaID});
            }
            catch
            {
                return View();
            }
        }

        // GET: /Tienda/Delete/5 
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var tienda = administracionFachada.getTienda(id);
            if (tienda == null)
                return View("NotFound");
            else
                return View(tienda);
        }

        // POST: /Tienda/Delete/5
        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var tienda = administracionFachada.getTienda(id);
            if (tienda == null)
            {
                return View("NotFound");
            }
            administracionFachada.deleteTienda(id);
            administracionFachada.saveTienda();
            return View("Deleted");
        }
    }
}
