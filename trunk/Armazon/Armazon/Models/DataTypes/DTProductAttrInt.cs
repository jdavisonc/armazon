using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProductAttrInt : DTProductAttr
    {
        private int _valor;

        public int Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public DTProductAttrInt(int id, string nombre, int valor) : base(nombre, id)
        {
            _valor = valor;
        }

        public override Types GetCustomType()
        {
            return Types.Int;
        }
    }
}
