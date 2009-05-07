using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DatabaseAccess;
using Armazon.Models;

namespace Armazon.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/

        public ActionResult Index()
        {
            AdministracionFachada adminSuc = new AdministracionFachada();
            var sucursales = adminSuc.findAllSucursales().ToList();
            return View(sucursales);

        }

        //
        // GET: /Sucursal/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada adminSuc = new AdministracionFachada();
            var sucursal = adminSuc.geSucursal(id);
            return View(sucursal);
        }

        //
        // GET: /Sucursal/Create

        public ActionResult Create()
        {
            AdministracionFachada adminSuc = new AdministracionFachada();
            Sucursal suc = new Sucursal();
            return View();
        } 

        //
        // POST: /Sucursal/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Sucursal suc = new Sucursal();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(suc);
                AdministracionFachada adminSuc = new AdministracionFachada();
                adminSuc.addSucursal(suc);
                adminSuc.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Sucursal/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada adminSuc = new AdministracionFachada();
            var sucursal = adminSuc.geSucursal(id); 
            return View(sucursal);
        }

        //
        // POST: /Sucursal/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada adminFac = new AdministracionFachada();
                Sucursal suc = adminFac.geSucursal(id);
                suc.Direccion = Request.Form["Direccion"];
                suc.Nombre = Request.Form["Nombre"];
                suc.SucursalID = int.Parse(Request.Form["SucursalID"]);
                suc.Latitud =  float.Parse(Request.Form["Latitud"]);
                suc.Longitud = float.Parse(Request.Form["Longitud"]);
                
                adminFac.save();
                return RedirectToAction("Details", new { id = suc.SucursalID });
                //return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var suc = adminFac.geSucursal(id);
            if (suc == null)
                return View("NotFound");
            else
                return View(suc);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var suc = adminFac.geSucursal(id);
            if (suc == null)
                return View("NotFound");
            adminFac.deleteSucursal(id);
            adminFac.save();
            return View("Deleted");
        }    
    
    
    }

        


}
