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

        public IQueryable<Producto> productosMasImportantes()
        {
            ProductoManager productoMgr = new ProductoManager();
            return productoMgr.findAllProductos();
        }
        
    }
}
