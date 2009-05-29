using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace Armazon.Models.DataTypes
{
    public class DTCarroVendido
    {
        private DTCarrito _datosCarrito;
        private List<DTPedido> _productos;

        public DTCarroVendido(DTCarrito datosCarrito, List<DTPedido> productos)
        {
            _datosCarrito = datosCarrito;
            _productos = productos;
        }
        public DTCarrito DatosCarrito
        { 
            get{ return  _datosCarrito;}
            set{ _datosCarrito = value;}
        }
        public List<DTPedido> Productos
        {
            get { return _productos; }
            set { _productos = value; }
        }    
    
    }
}
