using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class ImagenManager
    {
        private static ImagenManager instancia = null;
        private ArmazonDataContext db;

        private ImagenManager()
        {
            db = new ArmazonDataContext();            
        }

        public static ImagenManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new ImagenManager();
            }
            return instancia;
        }

        public IQueryable<Imagen> findAllTags()
        {
            return db.Imagens;
        }

        public Imagen getImagen(int id)
        {
            return db.Imagens.SingleOrDefault(c => c.ImagenID == id);                
        }

        public IQueryable<Imagen> getImagenDeProducto(int productID)
        {
            return (from Imagen v in db.Imagens
                           where v.ProductoID == productID
                           select v);
        }


        public void Add(Imagen imagen)
        {
            db.Imagens.InsertOnSubmit(imagen);
        }

        public void Delete(Imagen imagen)
        {
            db.Imagens.DeleteOnSubmit(imagen);
        }

        public void Save()
        {
            db.SubmitChanges();
        }


    }
}
