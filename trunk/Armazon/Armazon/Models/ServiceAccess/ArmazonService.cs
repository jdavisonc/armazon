using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

namespace Armazon.Models.ServiceAccess
{
    public class ArmazonService : IAccessStore
    {
        private string _url;

        public ArmazonService(string url)
        {
            _url = url;
        }

        #region IAccessStore Members

        public List<DTProduct> searchProducts(string fullText)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
