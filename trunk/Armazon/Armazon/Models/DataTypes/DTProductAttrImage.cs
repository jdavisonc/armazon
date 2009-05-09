using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProductAttrImage
    {
        private byte[] _imagen;

        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public DTProductAttrImage()
        {
        }
    }
}
