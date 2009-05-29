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

namespace Armazon
{
    public class DTCarrito
    {
        private int idCarrito;

        public int IdCarrito
        {
            get { return idCarrito; }
            set { idCarrito = value; }
        }

        private Usuario usuario;

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private MetodoDePago metodoDePago;

        public MetodoDePago MetodoDePago
        {
            get { return metodoDePago; }
            set { metodoDePago = value; }
        }

        private System.Nullable<System.DateTime> fecha;

        public System.Nullable<System.DateTime> Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private System.Nullable<double> total;

        public System.Nullable<double> Total
        {
            get { return total; }
            set { total = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
}
