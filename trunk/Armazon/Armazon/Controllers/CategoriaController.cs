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
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categorias = administracionFachada.findAllCategorias().ToList();
            
            return View(categorias);
        }

        //
        // GET: /Categoria/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            Categoria categoria = administracionFachada.getCategoria(id);
            if (categoria == null)
                return View("NotFound");
            else
                return View(categoria);
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Categoria/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Categoria categoria = new Categoria();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(categoria);
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addCategoria(categoria);
                administracionFachada.saveCategoria();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categoria/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categoria = administracionFachada.getCategoria(id);
            return View(categoria);
        }

        //
        // POST: /Categoria/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                Categoria categoria = administracionFachada.getCategoria(id);
                categoria.Nombre = Request.Form["Nombre"];
                administracionFachada.saveCategoria();
                return RedirectToAction("Details", new { id = categoria.CategoriaID });
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categoria = administracionFachada.getCategoria(id);
            if (categoria == null)
                return View("NotFound");
            else
                return View(categoria);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categoria = administracionFachada.getCategoria(id);
            if (categoria == null)
            {
                return View("NotFound");
            }
            administracionFachada.deleteCategoria(id);
            administracionFachada.saveCategoria();
            return View("Deleted");
        }

    }
}
