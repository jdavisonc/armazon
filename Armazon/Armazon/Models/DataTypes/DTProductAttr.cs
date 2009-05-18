using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTProductAttr
    {
        public enum Types
        {
            Int = 0,
            String = 1,
            Image = 2,
            Default = 9
        }

        private string _nombre;
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public DTProductAttr(string nombre, int id)
        {
            _nombre = nombre;
            _ID = id;
        }

        public virtual Types GetCustomType()
        {
            return Types.Default;
        }
        
    }
}
