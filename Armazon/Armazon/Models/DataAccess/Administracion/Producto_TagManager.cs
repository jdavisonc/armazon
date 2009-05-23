using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class Producto_TagManager
    {
        private ArmazonDataContext db;

        public Producto_TagManager()
        {
            db = new ArmazonDataContext();
        }


        public IQueryable<Producto_Tag> findAllProducto_Tags()
        {
            return db.Producto_Tags;
        }

        public Producto_Tag getProducto_Tag(int productoID, int tagID)
        {
            return db.Producto_Tags.SingleOrDefault(c => c.ProductoID == productoID && c.TagID == tagID);
        }

        public void Add(Producto_Tag producto_tag)
        {
            db.Producto_Tags.InsertOnSubmit(producto_tag);
        }

        public void Delete(Producto_Tag producto_Tag)
        {
            db.Producto_Tags.DeleteOnSubmit(producto_Tag);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
