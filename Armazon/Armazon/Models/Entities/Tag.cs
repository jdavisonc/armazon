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
using System.Collections.Generic;

namespace Armazon
{
    public partial class Tag
    {
        #region DataType
        public DTTag getDataType()
        {
            DTTag dt = new DTTag();
            dt.Id = this._TagID;
            dt.Nombre = this._Nombre;
            dt.CantAp = this._CantAp;
            return dt;
        }
        #endregion
    }
}
