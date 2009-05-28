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
            dt.Precio = this.Precio;
            if (this.Tienda != null)
            {
                dt.Tienda = this.Tienda.TiendaID;
                dt.ExternalID = this.ExternalID.Value;
            }
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
            List<string> tags = new List<string>();
            foreach (Producto_Tag prod_tag in this.Producto_Tags)
            {
                tags.Add(prod_tag.Tag.Nombre);
            }
            dt.Tags = tags;
            List<DTImagen> images = new List<DTImagen>();
            foreach (Imagen img in this.Imagens)
            {
                DTImagen dtimg = new DTImagen();
                dtimg.Id = img.ImagenID;
                dtimg.Nombre = img.Nombre;
                dtimg.ThumbailURL = img.ThumbnailURL;
                dtimg.ImagenURL = img.ImagenURL;
                images.Add(dtimg);
            }
            dt.Images = images;
            List<DTComment> comments = new List<DTComment>();
            foreach (Producto_Usuario com in this.Producto_Usuarios)
            {
                comments.Add(com.getDataType());
            }
            dt.Comments = comments;
            return dt;
        }
        #endregion
    }
}
