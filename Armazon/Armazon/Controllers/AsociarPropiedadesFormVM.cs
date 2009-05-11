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
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Armazon.Controllers
{
    public class AsociarPropiedadesFormVM
    {
        private SubCategoria subCategoria;
        public List<Propiedad> disponibles;
        private List<Propiedad> asociadas;

        public SubCategoria getSubCategoria()
        {
            return this.subCategoria;
        }

        public void setSubCategoria(SubCategoria subCategoria)
        {
            this.subCategoria = subCategoria;
        }

        public List<Propiedad> getDisponibles()
        {
            return this.disponibles;
        }

        public void setDisponibles(List<Propiedad> disponibles)
        {
            this.disponibles = disponibles;
        }

        public List<Propiedad> getAsociadas()
        {
            return this.asociadas;
        }

        public void setAsociadas(List<Propiedad> asociadas)
        {
            this.asociadas = asociadas;
        }
    }
}
