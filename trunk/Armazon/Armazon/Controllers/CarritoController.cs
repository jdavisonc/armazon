using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using MvcApplication1.Controllers;
using System.Web.Security;

namespace Armazon.Controllers
{
    public class CarritoController : Controller
    {
        //
        // GET: /Carrito/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();

            return View(adminFac.getCarritoOfUser(userName));
        }

        //
        // GET: /Carrito/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Carrito/Create

        public ActionResult Create()
        {
            
            return View();
        } 

        //
        // POST: /Carrito/Create

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
        // GET: /Carrito/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Carrito/Edit/5

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
