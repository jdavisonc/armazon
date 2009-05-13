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
using System.Collections.Generic;

namespace Armazon.Controllers.ViewModels
{
    public class DetalleProductoFromVM
    {
        private Producto producto;
        private List<Valor> valores;

        public Producto getProducto()
        {
            return this.producto;
        }

        public void setProducto(Producto producto)
        {
            this.producto = producto;
        }

        public List<Valor> getValores()
        {
            return this.valores;
        }

        public void setValores(List<Valor> valores)
        {
            this.valores = valores;
        }
    }
}
