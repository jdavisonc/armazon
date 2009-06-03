using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models.DataAccess.Administracion;
using Armazon.Models;
using Armazon.Models.DataTypes;

namespace Armazon.Controllers
{
    public class CarrosVendidosController : Controller
    {
        //
        // GET: /CarrosVendidos/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            List<Carrito> lcarrito = adminFac.getCarritosVendidosAUsuario();
            List<DTCarroVendido> lvendidos = new List<DTCarroVendido>();
            foreach (Carrito auxcarro in lcarrito)
            {
                DTCarrito dtcarrito = auxcarro.getDataType();
                List<DTPedido> lpedidos = adminFac.getProductosDeCarrito(auxcarro.CarritoID);
                DTCarroVendido dtvendido = new DTCarroVendido(dtcarrito,lpedidos);
                lvendidos.Add(dtvendido);
            }
            return View(lvendidos);
        }

        //
        // GET: /CarrosVendidos/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CarrosVendidos/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /CarrosVendidos/Create

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
        // GET: /CarrosVendidos/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CarrosVendidos/Edit/5

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
