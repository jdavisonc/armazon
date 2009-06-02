using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon.Models.DataTypes;

namespace Armazon.Models.ServiceAccess
{
    public interface IAccessStore
    {
        List<Producto> searchProducts(string fullText, Tienda tienda);
        Producto getProduct(string externalID, Tienda tienda);
        bool cartBuy(List<DCCartItem> cart, Tienda tienda);
    }
}
