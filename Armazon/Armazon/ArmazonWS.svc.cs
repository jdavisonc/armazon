using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Armazon.Models.DataAccess.Administracion;
using System.Collections;
using Armazon.ArmazonWS;

namespace Armazon.Models.ServiceAccess
{
    public class ArmazonWS : IArmazonWS
    {
        #region Auxiliar Methods

        private DCProduct getDataContract(Producto p)
        {
            List<DCProductAttr> attrs = new List<DCProductAttr>();
            DCProduct dc = new DCProduct();
            dc.ProductId = p.ProductoID;
            DCProductAttrString nombre = new DCProductAttrString();
            nombre.Name = "Nombre";
            nombre.IsKey = true;
            nombre.Value = p.Nombre;
            attrs.Add(nombre);
            DCProductAttrDouble precio = new DCProductAttrDouble();
            precio.Name = "Precio";
            precio.IsKey = false;
            precio.Value = p.Precio;
            attrs.Add(precio);
            foreach (Valor v in p.Valors)
            {
                DCProductAttrString at = new DCProductAttrString();
                at.Name = v.Propiedad.Nombre;
                at.IsKey = false;
                at.Value = v.Valor1;
                attrs.Add(at);
            }
            string baseURL = System.Configuration.ConfigurationSettings.AppSettings["baseURL"] + "Producto/ShowImage?productID=" + p.ProductoID + "&imageID=";
            foreach (Imagen img in p.Imagens)
            {
                DCProductAttrImage dcimg = new DCProductAttrImage();
                dcimg.Name = img.Nombre;
                dcimg.IsKey = false;
                dcimg.Url = baseURL + img.ImagenID;
                attrs.Add(dcimg);
            }
            dc.Attrs = attrs.ToArray();
            return dc;
        }

        #endregion


        #region IArmazonWS Members

        public ICollection<DCProduct> search(string fullText)
        {
            ICollection<DCProduct> col = new List<DCProduct>();
            ProductoManager productoMgr = new ProductoManager();
            IQueryable<Producto> productosArmazon = productoMgr.findAllProductos(fullText);
            foreach (Producto item in productosArmazon)
            {
                col.Add(getDataContract(item));
            }
            return col;
        }

        public DCProduct getProduct(int idProduct)
        {
            ProductoManager productoMgr = new ProductoManager();
            Producto p = productoMgr.getProducto(idProduct);
            if (p != null)
            {
                return getDataContract(p);
            }
            return null;
        }

        public ICollection<DCRating> getRatings(int idProduct)
        {
            ICollection<DCRating> col = new List<DCRating>();
            ProductoManager productoMgr = new ProductoManager();
            Producto p = productoMgr.getProducto(idProduct);
            if (p != null)
            {
                foreach (Producto_Usuario comment in p.Producto_Usuarios)
                {
                    DCRating rat = new DCRating();
                    rat.Comment = comment.Comentario;
                    rat.Rating = int.Parse(comment.Puntaje.ToString());
                    col.Add(rat);
                }
            }
            return col;
        }

        public bool CartBuy(string user, ICollection<DCCartItem> items)
        {
            ConsultaFachada consFac = new ConsultaFachada();
            return consFac.CartBuy(user, items);
        }

        #endregion
    }
}
