using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProductAttrImage : DTProductAttr
    {
        private byte[] _imagen;

        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public DTProductAttrImage(int id, string nombre, byte[] imagen) : base(nombre,id)
        {
            _imagen = imagen;
        }

        public override Types GetCustomType()
        {
            return Types.Image;
        }
    }
}
