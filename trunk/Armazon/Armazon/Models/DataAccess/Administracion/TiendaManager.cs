using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace Armazon.Models.DataAccess.Administracion
{
    public class TiendaManager
    {
        private static TiendaManager instancia = null;
        private ArmazonDataContext db;

        private TiendaManager()
        {
            db = new ArmazonDataContext();
        }
        public static TiendaManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new TiendaManager();
            }
            return instancia;
        }
        public IQueryable<Tienda> findAllTiendas()
        {
            return db.Tiendas;
        }        
        public Tienda getTienda(int id)
        {
            return db.Tiendas.SingleOrDefault(c=> c.TiendaID==id);
        }
        public void Add(Tienda tienda)
        {
            db.Tiendas.InsertOnSubmit(tienda);
        }
        public void Delete(Tienda tienda)
        {
            db.Tiendas.DeleteOnSubmit(tienda);
        }
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}