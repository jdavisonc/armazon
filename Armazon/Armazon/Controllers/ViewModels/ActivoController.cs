using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
namespace Armazon.Controllers.ViewModels
{
    public class ActivoController : Controller
    {
        //
        // GET: /Activo/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Activo/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            Activo activo = adminFac.getCarritoActivoById(id);
            return View(activo);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Details(int id, string confirmButton)
        {
            /*AdministracionFachada adminFac = new AdministracionFachada();
            Activo activo = adminFac.getCarritoActivoById(id);
            if (metodo == null)
                return View("NotFoundPayPal");
            
            adminFac.saveMetodoDePago();*/
            return RedirectToAction("Home");
        }
        
        
        //
        // GET: /Activo/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Activo/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Activo/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Activo/Edit/5

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
