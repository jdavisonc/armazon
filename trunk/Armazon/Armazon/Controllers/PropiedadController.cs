using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;

namespace Armazon.Controllers
{
    public class PropiedadController : Controller
    {
        //
        // GET: /Propiedad/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var propiedades = administracionFachada.findAllPropiedades().ToList();

            return View(propiedades);
        }

        //
        // GET: /Propiedad/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            Propiedad propiedad = administracionFachada.getPropiedad(id);
            if (propiedad == null)
                return View("NotFound");
            else
                return View(propiedad);
        }

        //
        // GET: /Propiedad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Propiedad/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Propiedad propiedad = new Propiedad();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(propiedad);
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addPropiedad(propiedad);
                administracionFachada.savePropiedad();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Propiedad/Edit/5

        public ActionResult Edit(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var propiedad = administracionFachada.getPropiedad(id);
            return View(propiedad);
        }

        //
        // POST: /Propiedad/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                Propiedad propiedad = administracionFachada.getPropiedad(id);
                propiedad.Nombre = Request.Form["Nombre"];
                administracionFachada.savePropiedad();
                return RedirectToAction("Details", new { id = propiedad.PropiedadID });

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var propiedad = administracionFachada.getPropiedad(id);
            if (propiedad == null)
                return View("NotFound");
            else
                return View(propiedad);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var propiedad = administracionFachada.getPropiedad(id);
            if (propiedad == null)
            {
                return View("NotFound");
            }
            administracionFachada.deletePropiedad(id);
            administracionFachada.savePropiedad();
            return View("Deleted");
        }

    }
}
