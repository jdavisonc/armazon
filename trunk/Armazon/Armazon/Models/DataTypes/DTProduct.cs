using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProduct
    {
        private int _id;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DTProduct(int id)
        {
            _id = id;
        }
        
    }
}
