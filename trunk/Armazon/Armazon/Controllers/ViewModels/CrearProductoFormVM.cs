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
    public class CrearProductoFormVM
    {
        private SubCategoria subCategoria;
        private List<Propiedad> propiedades;

        public SubCategoria getSubCategoria()
        {
            return this.subCategoria;
        }

        public void setSubCategoria(SubCategoria subCategoria)
        {
            this.subCategoria = subCategoria;
        }

        public List<Propiedad> getPropiedades()
        {
            return this.propiedades;
        }

        public void setPropiedades(List<Propiedad> propiedades)
        {
            this.propiedades = propiedades;
        }
    }
}
