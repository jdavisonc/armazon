using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

namespace Armazon
{
    public partial class Producto
    {
        #region CreateDataType
        public DTProduct getDataType()
        {
            DTProduct dt = new DTProduct();

            dt.Id = this._ProductoID;
            dt.Nombre = this.Nombre;
            if (this.SubCategoria != null)
            {
                dt.Subcategoria = this.SubCategoria.Nombre;
                dt.SubcaterogiaID = this.SubCategoriaID;
                dt.Categoria = this.SubCategoria.Categoria.Nombre;
                dt.CaterogiaID = this.SubCategoria.CategoriaID;
            }
            List<DTProductAttr> attrs = new List<DTProductAttr>();
            foreach (Valor item in this.Valors)
            {
                DTProductAttrString dtAttr = new DTProductAttrString(item.PropiedadID, item.Propiedad.Nombre, item.Valor1);
                attrs.Add(dtAttr);
            }
            dt.Attrs = attrs;
            return dt;
        }
        #endregion
    }
}
