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
using Armazon.Models.DataTypes;

namespace Armazon.Controllers.ViewModels
{
    public class BuscarProductoFormVM
    {
        public String FullText { get; set; }
        public List<Producto> lstProductos { get; set; }
        public List<DTProduct> dtProductos { get; set; }
        
    }
}
