using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
namespace Armazon.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var usuarios = adminFac.findAllUsuario();            
            return View(usuarios);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            Usuario usr = new Usuario();
            return View();
        } 

        //
        // POST: /Usuario/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Usuario usr = new Usuario();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(usr);
                AdministracionFachada adminFac = new AdministracionFachada();
                adminFac.addUsuario(usr);
                adminFac.saveUsuario();
                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
