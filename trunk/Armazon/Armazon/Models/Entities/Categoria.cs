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
    public partial class Categoria
    {
        #region DataType
        public DTCategoria getDataType()
        {
            DTCategoria dt = new DTCategoria();
            dt.Id = this._CategoriaID;
            dt.Nombre = this._Nombre;

            dt.SubCategorias = new List<DTSubCategoria>();
            foreach (SubCategoria s in this._SubCategorias)
            {
                dt.SubCategorias.Add(s.getDataType());
            }
            return dt;
        }
        #endregion
    }
}
