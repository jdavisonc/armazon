using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DatabaseAccess;
using Armazon.Models.DataAccess.Administracion;
using Armazon.Models.ServiceAccess;
using Armazon.Models.DataTypes;
using System.Collections.Generic;
using Armazon.ArmazonWS;

namespace Armazon.Models
{
    public class ConsultaFachada
    {
        public IEnumerable<Producto> findAllProductosXSubCategoria(int idSubCategoria)
        {
            List<Producto> resultadoBusqueda = new List<Producto>();
            ProductoManager productoMgr = new ProductoManager();
            IQueryable<Producto> productosArmazon = productoMgr.findAllProductosXSubCategoria(idSubCategoria);
            resultadoBusqueda.AddRange(productosArmazon);
            return resultadoBusqueda;
        }

        public IEnumerable<Producto> findAllProductos(String fullText)
        {
            List<Producto> resultadoBusqueda = new List<Producto>();
            TiendaManager tiendaMgr = new TiendaManager();
            // Busco productos sobre DB de Armazon
            ProductoManager productoMgr = new ProductoManager();
            resultadoBusqueda.AddRange(productoMgr.findAllProductos(fullText));
            foreach (Tienda tend in tiendaMgr.findAllTiendas())
            {
                if (tend.TipoAPI.CompareTo("ARMAZON") == 0)
                {
                    // Busco productos sobre DB de ARMAZON
                    IAccessStore ias = FabricAccessStore.getInstance().createArmazonServiceAccess();
                    resultadoBusqueda.AddRange(ias.searchProducts(fullText, tend));
                }
                else if (tend.TipoAPI.CompareTo("AMAZON") == 0)
                {
                    // Busco productos sobre DB de AMAZON
                    IAccessStore ias = FabricAccessStore.getInstance().createAmazonServiceAccess();
                    resultadoBusqueda.AddRange(ias.searchProducts(fullText,tend));                
                }
            }
            return resultadoBusqueda;
        }

        public Producto getProductoTienda(string externalID, int tiendaID)
        {
            TiendaManager tiendaMgr = new TiendaManager();
            Tienda tend = tiendaMgr.getTienda(tiendaID);
            if (tend != null)
            {
                if (tend.TipoAPI.CompareTo("ARMAZON") == 0)
                {
                    // Busco productos sobre DB de ARMAZON
                    IAccessStore ias = FabricAccessStore.getInstance().createArmazonServiceAccess();
                    return ias.getProduct(externalID, tend);
                }
                else if (tend.TipoAPI.CompareTo("AMAZON") == 0)
                {
                    // Busco productos sobre DB de AMAZON
                    IAccessStore ias = FabricAccessStore.getInstance().createAmazonServiceAccess();
                    return ias.getProduct(externalID, tend);
                }
            }
            return null;
        }

        public IQueryable<Producto> productosMasImportantes()
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.findAllProductos();
        }

        public IEnumerable<Producto> findProductosPorTag(String nombreTag)
        {            
            List<Producto> resultadoBusqueda = new List<Producto>();
            TagManager tagMgr = new TagManager();
            IEnumerable<Producto_Tag> pt = tagMgr.getTag(nombreTag).Producto_Tags;
            foreach (Producto_Tag pTag in pt)
            {
                resultadoBusqueda.Add(pTag.Producto);                
            }
            return resultadoBusqueda;         
        }

		public bool CartBuy(string user, ICollection<DCCartItem> items)
        {
            UsuarioManager usrMgr = new UsuarioManager();
            ProductoManager prodMgr = new ProductoManager();
            CarritoManager carrMgr = new CarritoManager();
            Usuario usr = usrMgr.getUsuario(user);
            Carrito carrito = new Carrito();
            carrito.CarritoType = "Vendido";
            carrito.UsuarioID = usr.UsuarioID;
            carrMgr.AddCarritoActivo(carrito);
            List<Producto> lproductos = new List<Producto>();
            foreach (DCCartItem aux in items)
            {                
                carrMgr.AgregarProductoCarrito(aux.ProductId, carrMgr.getCarritoActivoByUser(usr.UsuarioID).CarritoID, aux.Quantity);
            }
            double monto = prodMgr.getMontoProductos(items);
            carrito.Total = monto;
            carrMgr.Save();
            return true;
        }
        
        public IEnumerable<Producto> productosRecomendados(Producto producto)
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.productosRecomendados(producto);
        }

        public IEnumerable<Producto> productosRecomendados(Usuario usuario)
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.productosRecomendados(usuario);
        }

        public IEnumerable<Producto> productosRecomendados()
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.productosRecomendados();
        }

        public IEnumerable<Producto> productosAleatorios()
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.productosAleatorios();
        }
    }
}
