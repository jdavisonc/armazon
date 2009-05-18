using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProductAttrString : DTProductAttr
    {
        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public DTProductAttrString(int id, string nombre, string valor) : base (nombre, id)
        {
            _valor = valor;
        }

        public override Types GetCustomType()
        {
            return Types.String;
        }

    }
}
