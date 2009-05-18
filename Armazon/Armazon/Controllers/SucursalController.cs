using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using DatabaseAccess;
using Armazon.Models;
using Armazon.Models.DataTypes;

namespace Armazon.Controllers
{
    public class SucursalController : Controller
    {
        //
        // GET: /Sucursal/

        public ActionResult Index()
        {
            List<DTSucursal> dtCollection = new List<DTSucursal>();
            AdministracionFachada adminSuc = new AdministracionFachada();
            foreach (Sucursal item in adminSuc.findAllSucursales().ToList())
            {
                dtCollection.Add(item.getDataType());
            }
            return View(dtCollection);
        }

        //
        // GET: /Sucursal/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada adminSuc = new AdministracionFachada();
            var sucursal = adminSuc.getSucursal(id);
            if (sucursal == null)
                return View("NotFound");
            return View(sucursal.getDataType());
        }

        //
        // GET: /Sucursal/Create

        public ActionResult Create()
        {
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
                suc.Direccion = Request.Form["Direccion"];
                suc.Nombre = Request.Form["Nombre"];
                suc.Latitud = float.Parse((Request.Form["Latitud"]).Replace('.',','));
                suc.Longitud = float.Parse((Request.Form["Longitud"]).Replace('.',','));
                AdministracionFachada adminSuc = new AdministracionFachada();
                adminSuc.addSucursal(suc);
                adminSuc.saveSucursal();
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
            var sucursal = adminSuc.getSucursal(id);
            if (sucursal == null)
                return View("NotFound");
            return View(sucursal.getDataType());
        }

        //
        // POST: /Sucursal/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada adminFac = new AdministracionFachada();
                Sucursal suc = adminFac.getSucursal(id);
                suc.Direccion = Request.Form["Direccion"];
                suc.Nombre = Request.Form["Nombre"];
                suc.Latitud = float.Parse((Request.Form["Latitud"]).Replace('.', ','));
                suc.Longitud = float.Parse((Request.Form["Longitud"]).Replace('.', ','));
                adminFac.saveSucursal();
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
            var suc = adminFac.getSucursal(id);
            if (suc == null)
                return View("NotFound");
            else
                return View(suc.getDataType());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var suc = adminFac.getSucursal(id);
            if (suc == null)
                return View("NotFound");
            adminFac.deleteSucursal(id);
            adminFac.saveSucursal();
            return View("Deleted");
        }

        public ActionResult ViewMap()
        {
            return View();
        }

        public ActionResult GetMap()
        {
            Map map = new Map();
            map.Name = "Sucursales Armazon";
            map.Zoom = 12;
            map.LatLng = new LatLng { Latitude = -34.888916, Longitude = -56.162281 };
            map.Locations = new List<Location>();
            AdministracionFachada adminFac = new AdministracionFachada();
            foreach (Sucursal s in adminFac.findAllSucursales())
            {
                Location l = new Location();
                l.Name = s.Nombre;
                l.Address = s.Direccion;
                l.LatLng = new LatLng { Latitude = s.Latitud, Longitude = s.Longitud };
                map.Locations.Add(l);
            }
            return Json(map);
        }
    }

        


}
