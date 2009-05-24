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
using System.Drawing;
using System.Web.UI;
using System.Web.Security;
using System.Data.Linq;

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
        
        public ActionResult AgregarProducto(string cant,string idProducto)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            int usuarioId = adminFac.getUsuario(userName).UsuarioID;
            Carrito carroActivo = adminFac.getCarritoActivoByUser(usuarioId);
            int carritoId = carroActivo.CarritoID;
            
            adminFac.AgregarProductoCarrito(int.Parse(idProducto), carritoId,int.Parse(cant));
            List<DTPedido> prods = adminFac.getProductosDeCarrito(carritoId);
            double montoProductos = adminFac.getMontoProductos(prods);
            AddProductoCarrito prodsCarrito = new AddProductoCarrito();
            prods.Reverse();    
            prodsCarrito.MontoActual = montoProductos;
            prodsCarrito.Productos = prods;
            return Json(prodsCarrito);




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
                return View("Details",producto.getDataType());
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
                foreach (string inputTagName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[inputTagName];
                    if (file.ContentLength > 0)
                    {
                        byte[] buf = new byte[file.ContentLength];
                        file.InputStream.Read(buf, 0, file.ContentLength);
                        Imagen img = new Imagen();
                        img.Nombre = Path.GetFileName(file.FileName);
                        img.ProductoID = producto.ProductoID;
                        img.MIMEType = file.ContentType;
                        img.Imagen1 = buf;
                        Image thumbnail = Image.FromStream(file.InputStream).
                            GetThumbnailImage(150, 150, null, new System.IntPtr());
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            thumbnail.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img.Thumbnail = ms.ToArray();
                        }
                        producto.Imagens.Add(img);
                    }
                }
                administracionFachada.saveProducto();
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

        public ActionResult Listado(int idSubCategoria)
        {
            ConsultaFachada consultaFachada = new ConsultaFachada();
            IEnumerable<Producto> productosXSubCategoria = consultaFachada.findAllProductosXSubCategoria(idSubCategoria);
            List<DTProduct> dtCol = new List<DTProduct>();
            foreach (Producto p in productosXSubCategoria)
            {
                dtCol.Add(p.getDataType());
            }
            AdministracionFachada aFachada = new AdministracionFachada();
            
            ViewData["SubCategoriaID"] = idSubCategoria;
            ViewData["SubCategoriaNombre"] = aFachada.getSubCategoria(idSubCategoria).Nombre;
            ViewData["CategoriaID"] = aFachada.getSubCategoria(idSubCategoria).CategoriaID;
            ViewData["CategoriaNombre"] = aFachada.getSubCategoria(idSubCategoria).Categoria.Nombre;
            ViewData["Title"] = "Listado de Productos";
            return View("List",dtCol);
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
            ViewData["Title"] = "Resultado de Busqueda";
            return View("List",dtCollection);
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
                        t.Nombre = tag;
                        t.CantAp = 0;
                        adminFach.AddTag(t);
                        adminFach.SaveTags();
                    }
                    if (adminFach.getProducto_Tag(productID, t.TagID) == null)
                    {
                        MembershipUser myObject = Membership.GetUser();
                        string userName = myObject.UserName.ToString();                   
                        Producto_Tag pt = new Producto_Tag();
                        pt.ProductoID = productID;
                        //pt.Producto = adminFach.getProducto(productID);
                        pt.TagID = t.TagID;
                        //pt.Tag = t;
                        pt.UsuarioID = adminFach.getUsuario(userName).UsuarioID;
                        adminFach.AddProducto_Tag(pt);
                        //adminFach.getProducto(productID).Producto_Tags.Add(pt);
                        adminFach.SaveProducto_Tag();
                        // Solo sumo si el tag no esta asociado al producto
                        t.CantAp++;
                        adminFach.SaveTags();
                    }
                }
            }
            else
            {
                // Error no existe el producto
            }
            return Details(productID);
        }

        public ActionResult ShowFirstThumbnail(int productID)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            EntitySet<Imagen> set = adminFach.getProducto(productID).Imagens;
            if ((set.Count > 0) && (set[0] != null))
                return File(set[0].Thumbnail.ToArray(), "image/jpg");
            else
                return null;
        }

        public ActionResult ShowThumbnail(int productID, int imageID)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            foreach (Imagen img in adminFach.getProducto(productID).Imagens)
            {
                if (img.ImagenID == imageID)
                    return File(img.Thumbnail.ToArray(), "image/jpg");
            }
            return null;
        }

        public ActionResult ShowImage(int productID, int imageID)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            foreach (Imagen img in adminFach.getProducto(productID).Imagens)
            {
                if (img.ImagenID == imageID)
                    return File(img.Imagen1.ToArray(), img.MIMEType);
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult DeleteImage(int productID, int imageID)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            Producto p = adminFach.getProducto(productID);
            if (p != null)
            {
                Imagen img = adminFach.getImagen(imageID);
                if (img != null)
                {
                    adminFach.deleteImagen(imageID);
                    adminFach.saveImagen();
                    return Json(true);
                }
            }
            return Json(false);
        }		
        [AcceptVerbs(HttpVerbs.Post)]        
		public ActionResult CrearProducto(int idSubCategoria, int idCategoria)        
		{            
			AdministracionFachada administracionFachada = new AdministracionFachada();            
			String strNombre = Request.Form["txtNombre"];            
			float precio = float.Parse(Request.Form["txtPrecio"]);            
			Producto nuevoProducto = new Producto();            
			nuevoProducto.SubCategoriaID = idSubCategoria;            
			nuevoProducto.Nombre = strNombre;            
			nuevoProducto.Precio = precio;            
			administracionFachada.addProducto(nuevoProducto);            
			//administracionFachada.saveProducto();            
			//Producto producto = administracionFachada.getProducto(strNombre);            
			//int idProducto = producto.ProductoID;            
			NameValueCollection parametros = Request.Params;            
			for (int i = 0; i < parametros.Count; i++)            
			{                
				String strParametro = parametros.GetKey(i);                
				String strValor = parametros.Get(i);                
				int parametro;                
				if (int.TryParse(strParametro, out parametro)){                    
					Propiedad pp = administracionFachada.getPropiedad(parametro);                    
					Valor nuevo = new Valor();                    
					nuevo.Producto = nuevoProducto;                    
					//nuevo.ProductoID = idProducto;                    
					//nuevo.PropiedadID = parametro;                    
					nuevo.Propiedad = pp;                    
					nuevo.Valor1 = strValor;                    
					//administracionFachada.addValor(nuevo);                    
					//administracionFachada.saveValor();                
				}
			}            
			var subCategorias = administracionFachada.findAllSubCategorias(idCategoria).ToList();            
			ViewData["CategoriaID"] = idCategoria;            
			/**/            
			administracionFachada.saveProducto();            
			return View("ListarSubCategoria", subCategorias);
		}		   
	}
}
