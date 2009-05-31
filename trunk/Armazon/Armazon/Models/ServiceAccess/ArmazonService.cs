using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;
using Armazon.ArmazonWS;

namespace Armazon.Models.ServiceAccess
{
    public class ArmazonService : IAccessStore
    {

        public ArmazonService()
        {
        }

        #region Auxiliar Methods

        private Producto getProductoFromDataContract(DCProduct dc)
        {
            Producto producto = new Producto();
            producto.ExternalID = dc.ProductId.ToString();
            foreach (DCProductAttr attr in dc.Attrs)
            {
                if (attr.Name.CompareTo("Nombre") == 0)
                {
                    producto.Nombre = ((DCProductAttrString)attr).Value;
                }
                else if (attr.Name.CompareTo("Precio") == 0)
                { 
                    if (attr.GetType() == typeof(DCProductAttrString))
                    {
                        producto.Precio = double.Parse(((DCProductAttrString)attr).Value);
                    }
                    else if (attr.GetType() == typeof(DCProductAttrDouble))
                    {
                        producto.Precio = ((DCProductAttrDouble)attr).Value;
                    }
                }
                else if (attr.GetType() == typeof(DCProductAttrImage))
                {
                    Imagen img = new Imagen();
                    img.Nombre = attr.Name;
                    img.ImagenURL = ((DCProductAttrImage)attr).Url;
                    producto.Imagens.Add(img);
                }
                else
                {
                    Propiedad prop = new Propiedad();
                    prop.Nombre = attr.Name;
                    Valor v = new Valor();
                    v.Propiedad = prop;
                    if (attr.GetType() == typeof(DCProductAttrBool))
                    {
                        v.Valor1 = ((DCProductAttrBool)attr).Value.ToString();
                    }
                    else if (attr.GetType() == typeof(DCProductAttrDouble))
                    {
                        v.Valor1 = ((DCProductAttrDouble)attr).Value.ToString();
                    }
                    else if (attr.GetType() == typeof(DCProductAttrFloat))
                    {
                        v.Valor1 = ((DCProductAttrFloat)attr).Value.ToString();
                    }
                    else if (attr.GetType() == typeof(DCProductAttrInt))
                    {
                        v.Valor1 = ((DCProductAttrInt)attr).Value.ToString();
                    }
                    else if (attr.GetType() == typeof(DCProductAttrString))
                    {
                        v.Valor1 = ((DCProductAttrString)attr).Value;
                    }
                    producto.Valors.Add(v);
                }
            }
            return producto;
        }

        #endregion

        #region IAccessStore Members

        public List<Producto> searchProducts(string fullText, Tienda tienda)
        {
            List<Producto> productos = new List<Producto>();
            Armazon.ArmazonWS.ArmazonWSClient ws = new Armazon.ArmazonWS.ArmazonWSClient();
            ws.Endpoint.Address = new System.ServiceModel.EndpointAddress(tienda.Url);
            DCProduct[] col = ws.search(fullText);
            foreach (DCProduct item in col)
            {
                Producto p = getProductoFromDataContract(item);
                p.Tienda = tienda;
                productos.Add(p);
            }
            return productos;
        }

        public Producto getProduct(string externalID, Tienda tienda)
        {
            Armazon.ArmazonWS.ArmazonWSClient ws = new Armazon.ArmazonWS.ArmazonWSClient();
            ws.Endpoint.Address = new System.ServiceModel.EndpointAddress(tienda.Url);
            DCProduct dc = ws.getProduct(int.Parse(externalID));
            Producto p = getProductoFromDataContract(dc);
            p.Tienda = tienda;

            DCRating [] ratings = ws.getRatings(int.Parse(externalID));
            foreach (DCRating rat in ratings)
            {
                Producto_Usuario com = new Producto_Usuario();
                com.Comentario = rat.Comment;
                com.Puntaje = rat.Rating;
                p.Producto_Usuarios.Add(com);
            }
            return p;
        }

        #endregion
    }
}
