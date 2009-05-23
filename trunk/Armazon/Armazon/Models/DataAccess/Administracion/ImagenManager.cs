using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class ImagenManager
    {
        private ArmazonDataContext db;

        public ImagenManager()
        {
            db = new ArmazonDataContext();
        }
        public void addImagen(Imagen img)
        {
            db.Imagens.InsertOnSubmit(img);
        }
        public Imagen getImagen(int id)
        {
            return db.Imagens.SingleOrDefault(c=> c.ImagenID == id);
        }
        public void DeleteImagen(int id)
        {
            db.Imagens.DeleteOnSubmit(getImagen(id));
        }
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
