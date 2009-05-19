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
using System.IO;

namespace Armazon.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            /*List<DTProduct> dtCollection = new List<DTProduct>();
            AdministracionFachada administracionFachada = new AdministracionFachada();
            foreach (Producto prod in administracionFachada.findAllProductos())
            {
                dtCollection.Add(prod.getDataType());
            }  
            return View(dtCollection);*/
            return View("NotFound");
        }

        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            Producto producto = administracionFachada.getProducto(id);
            if (producto == null)
                return View("NotFound");
            else
                return View(producto.getDataType());
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
            Producto producto = administracionFachada.getProducto(id);
            return View(producto.getDataType());
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
                producto.Precio = Double.Parse(Request.Form["txtPrecio"]);
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
                foreach (HttpPostedFile file in Request.Files)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    byte[] buf = new byte[file.ContentLength];
                    file.InputStream.Read(buf, 0, file.ContentLength);

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
                return View(producto.getDataType());
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
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BuscarProducto(String fullText)
        {
            List<DTProduct> dtCollection = new List<DTProduct>();
            ConsultaFachada consultaFachada = new ConsultaFachada();
            foreach (Producto prod in consultaFachada.findAllProductos(fullText))
            {
                dtCollection.Add(prod.getDataType());
            }
            return View(dtCollection);
        }

        /// <summary>
        /// Recibo una coleccion de tags separadas por coma (",") en un string y las ingreso al 
        /// sistema
        /// </summary>
        /// <param name="productID">Identificador del producto a ingresar las tags</param>
        /// <param name="tagCollection">Coleccion de tags</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddTag(int productID, string tagCollection)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            if (adminFach.getProducto(productID) != null)
            {
                string[] tags = tagCollection.Split(',');
                foreach (string tag in tags)
                {
                    Tag t = adminFach.getTag(tag);
                    if (t == null)
                    {
                        t = new Tag();
                        t.CantAp = 0;
                        adminFach.AddTag(t);
                        adminFach.SaveTags();
                    }
                    if (adminFach.getProducto_Tag(productID, t.TagID) == null)
                    {
                        Producto_Tag pt = new Producto_Tag();
                        pt.ProductoID = productID;
                        pt.TagID = t.TagID;
                        adminFach.AddProducto_Tag(pt);
                        adminFach.SaveProducto_Tag();
                        // Solo sumo si el tag no esta asociado al producto
                        t.CantAp++;
                    }
                }
            }
            else
            {
                // Error no existe el producto
            }
            return Details(productID);
        }

        
    }
}
