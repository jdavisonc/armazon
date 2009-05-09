using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProduct
    {
        private int _id;
        private IList<DTProductAttr> _attrs;

        public IList<DTProductAttr> Attrs
        {
            get { return _attrs; }
            set { _attrs = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DTProduct()
        {
            _attrs = new List<DTProductAttr>();
        }
        
    }
}
