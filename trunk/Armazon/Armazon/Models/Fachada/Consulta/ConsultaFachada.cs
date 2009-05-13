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

namespace Armazon.Models
{
    public class ConsultaFachada
    {
        public IQueryable<Producto> findAllProductosXSubCategoria(int idSubCategoria)
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            return productoMgr.findAllProductosXSubCategoria(idSubCategoria);
        }
    }
}
