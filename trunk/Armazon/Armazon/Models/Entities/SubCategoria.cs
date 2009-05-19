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
    public partial class SubCategoria
    {
        #region DataType
        public DTSubCategoria getDataType()
        {
            DTSubCategoria dt = new DTSubCategoria();
            dt.Id = this._SubCategoriaID;
            dt.Nombre = this._Nombre;
            
            return dt;
        }
        #endregion
    }
}
