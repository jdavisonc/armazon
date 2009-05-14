using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using DatabaseAccess;
using Armazon.Controllers.ViewModels;
using System.Collections.Specialized;
using Armazon.Models.ServiceAccess;
using Armazon.Models.DataTypes;

namespace Armazon.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var productos = administracionFachada.findAllProductos().ToList();
            return View(productos);
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            Producto producto = administracionFachada.getProducto(id);

            DetalleProductoFromVM form = new DetalleProductoFromVM();

            List<Valor> lstValores = new List<Valor>();

            foreach (Valor v in administracionFachada.valoresProductos(id))
            {
                lstValores.Add(v);
            }

            form.setValores(lstValores);
            form.setProducto(producto);

            if (producto == null)
                return View("NotFound");
            else
                return View(form);
        }

        //
        // GET: /Producto/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Producto/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            Producto producto = new Producto();
            try
            {
                // TODO: Add insert logic here
                UpdateModel(producto);
                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addProducto(producto);
                administracionFachada.saveProducto();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Producto/Edit/5
 
        public ActionResult Edit(int id, int idSubCategoria)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            IQueryable<Propiedad> propiedades = administracionFachada.propiedadesSubCategoria(idSubCategoria);
            Producto producto = administracionFachada.getProducto(id);
            
            List<Valor> lstValor = new List<Valor>();
            foreach (Propiedad p in propiedades)
            {
                lstValor.Add(administracionFachada.getValor(id,p.PropiedadID));
            }
            ViewData["nmProducto"] = producto.Nombre;
            return View(lstValor);
        }

        //
        // POST: /Producto/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                Producto producto = administracionFachada.getProducto(id);
                producto.Nombre = Request.Form["txtNombre"];
                administracionFachada.saveProducto();

                NameValueCollection parametros = Request.Params;
                for (int i = 0; i < parametros.Count; i++)
                {
                    String strParametro = parametros.GetKey(i);
                    String strValor = parametros.Get(i);
                    int parametro;
                    if (int.TryParse(strParametro, out parametro))
                    {
                        Valor valor = administracionFachada.getValor(id,parametro);
                        valor.Valor1 = strValor;
                        administracionFachada.saveValor();
                    }
                }

                return RedirectToAction("Details", new { id = producto.ProductoID });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var producto = administracionFachada.getProducto(id);
            if (producto == null)
                return View("NotFound");
            else
                return View(producto);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var producto = administracionFachada.getProducto(id);
            if (producto == null)
            {
                return View("NotFound");
            }
            foreach (Valor v in producto.Valors)
            {
                administracionFachada.deleteValor(v.ProductoID, v.PropiedadID);
                administracionFachada.saveValor();
            }
            administracionFachada.deleteProducto(id);
            administracionFachada.saveProducto();
            return View("Deleted");
        }

        public ActionResult BuscarProducto()
        {
            BuscarProductoFormVM form = new BuscarProductoFormVM();
            form.dtProductos = new List<DTProduct>();
            form.lstProductos = new List<Producto>();
            form.FullText = "";
            return View(form);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BuscarProducto(String fullText)
        {
            ConsultaFachada consultaFachada = new ConsultaFachada();
            IQueryable<Producto> productos = consultaFachada.findAllProductos(fullText);
            
            List<Producto> lstProductos = new List<Producto>();
            if (productos != null)
            {
                foreach (Producto p in productos)
                {
                    lstProductos.Add(p);
                }
            }
            
            FabricAccessStore fas = FabricAccessStore.getInstance();
            IAccessStore service = fas.createAmazonServiceAccess();
            List<DTProduct> dtProductos = service.searchProducts(fullText);
            
            BuscarProductoFormVM form = new BuscarProductoFormVM();
            form.FullText = fullText;
            form.lstProductos = lstProductos;
            form.dtProductos = dtProductos;

            return View(form);
        }

        
    }
}
