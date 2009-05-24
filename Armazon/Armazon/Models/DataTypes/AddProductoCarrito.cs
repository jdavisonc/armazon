using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class AddProductoCarrito
    {
        private double _montoActual;
        private List<DTPedido> _productos;
        public AddProductoCarrito()
        {
            _montoActual = 0;
            _productos = null;
        }
        public double MontoActual
        {
            get{return _montoActual;}
            set{_montoActual = value;}
        }

        public List<DTPedido> Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }
    
    
    
    
    }
}
