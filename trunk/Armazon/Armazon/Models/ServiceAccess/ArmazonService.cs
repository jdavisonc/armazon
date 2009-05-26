using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

namespace Armazon.Models.ServiceAccess
{
    public class ArmazonService : IAccessStore
    {

        public ArmazonService()
        {
        }

        #region IAccessStore Members

        public List<Producto> searchProducts(string fullText, Tienda tienda)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
