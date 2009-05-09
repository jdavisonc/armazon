using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace Armazon.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Tag/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tag/Create

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
        // GET: /Tag/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Edit/5

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
