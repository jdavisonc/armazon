using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Armazon.Controllers
{
    public class TiendaController : Controller
    {
        //
        // GET: /Tienda/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tienda/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tienda/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tienda/Create

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
        // GET: /Tienda/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tienda/Edit/5

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
