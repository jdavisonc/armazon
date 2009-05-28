using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

namespace Armazon
{
    public partial class Producto_Usuario
    {
        #region CreateDataType
        public DTComment getDataType()
        {
            DTComment com = new DTComment();
            com.Comment = this.Comentario;
            com.Rating = this.Puntaje.Value;
            return com;
        }
        #endregion
    }
}
