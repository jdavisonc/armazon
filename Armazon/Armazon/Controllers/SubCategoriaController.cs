using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Armazon.Models;


namespace Armazon.Controllers
{
    public class SubCategoriaController : Controller
    {
        //
        // GET: /SubCategoria/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categorias = administracionFachada.findAllCategorias().ToList();

            return View(categorias);
        }

        //
        // GET: /SubCategoria/ListarSubCategoria/1

        public ActionResult ListarSubCategoria(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var subCategorias = administracionFachada.findAllSubCategorias(id).ToList();

            ViewData["CategoriaID"] = id;
            return View(subCategorias);
        }

        //
        // GET: /SubCategoria/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            SubCategoria subCategoria = administracionFachada.getSubCategoria(id);
            if (subCategoria == null)
                return View("NotFound");
            else
                return View(subCategoria);
        }

        //
        // GET: /Categoria/Create/2

        public ActionResult Create(int id)
        {
            ViewData["CategoriaID"] = id;
            return View();
        } 

        //
        // POST: /SubCategoria/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            SubCategoria subCategoria = new SubCategoria();
            try
            {
                UpdateModel(subCategoria);
                
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addSubCategoria(subCategoria);
                administracionFachada.saveSubCategoria();

                return RedirectToAction("ListarSubCategoria", new {id = subCategoria.CategoriaID });
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
            var subCategoria = administracionFachada.getSubCategoria(id);
            
            return View(subCategoria);
        }

        //
        // POST: /Categoria/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                SubCategoria subCategoria = administracionFachada.getSubCategoria(id);
                
                subCategoria.Nombre = Request.Form["Nombre"];
                
                administracionFachada.saveSubCategoria();
                
                return RedirectToAction("Details", new { id = subCategoria.SubCategoriaID });

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            
            var subCategoria = administracionFachada.getSubCategoria(id);

            if (subCategoria == null)
            {
                ViewData["CategoriaID"] = int.Parse(Request.Form["CategoriaID"]);
                return View("NotFound");
            }
            else 
            {
                return View(subCategoria);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, int categoriaID, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            
            var subCategoria = administracionFachada.getSubCategoria(id);

            ViewData["CategoriaID"] = categoriaID;

            if (subCategoria == null)
            {
                return View("NotFound");
            }

            administracionFachada.deleteSubCategoria(id);
            administracionFachada.saveSubCategoria();

            return View("Deleted");
        }
    }
}