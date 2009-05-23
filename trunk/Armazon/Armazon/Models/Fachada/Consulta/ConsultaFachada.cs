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

            // Busco productos sobre DB de Armazon
            ProductoManager productoMgr = new ProductoManager();
            IQueryable<Producto> productosArmazon = productoMgr.findAllProductos(fullText);
            resultadoBusqueda.AddRange(productosArmazon);

            // Busco productos sobre DB de Otros ARMAZON
            ///********* HACER *********/
            ///
            
            // Busco productos sobre DB de AMAZON
            IAccessStore ias = FabricAccessStore.getInstance().createAmazonServiceAccess();
            List<DTProduct> dtProducts = ias.searchProducts(fullText);
           
            // Paso de DTProduct a Producto para trabajar en el sistema con ellos
            /// ** Ver si agregar a la db una ves que se busca, o agregar a la db solo si se selecciona
            /// ** para comprar

            foreach (DTProduct item in dtProducts)
            {
                Producto prod = new Producto();
                foreach (DTProductAttr attr in item.Attrs)
                {
                    switch (attr.GetCustomType())
                    {
                        case DTProductAttr.Types.Int:
                            break;
                        case DTProductAttr.Types.String:
                            DTProductAttrString attrString = (DTProductAttrString)attr;
                            if (attrString.Nombre.CompareTo("Nombre") == 0)
                            {
                                prod.Nombre = attrString.Valor;
                            }
                            break;
                        case DTProductAttr.Types.Image:
                            break;
                        case DTProductAttr.Types.Default:
                            break;
                        default:
                            break;
                    }
                }
                resultadoBusqueda.Add(prod);
            }

            return resultadoBusqueda;
        }
        
    }
}
