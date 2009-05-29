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
using Armazon.Models.DataTypes;

namespace Armazon
{
    public partial class Carrito
    {
        #region DataType
        public DTCarrito getDataType()
        {
            DTCarrito dt = new DTCarrito();
            dt.IdCarrito = this._CarritoID;
            dt.Usuario = this._Usuario.Entity;
            dt.MetodoDePago = this._MetodoDePago.Entity;
            dt.Fecha = this._Fecha;
            dt.Total = this._Total;
            dt.Tipo = this.CarritoType;

            return dt;
        }
        #endregion
    }
}
