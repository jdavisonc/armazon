using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace DatabaseAccess
{
    public class SucursalManager
    {
        private static SucursalManager instancia = null;
        private ArmazonDataContext db;

        private SucursalManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static SucursalManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new SucursalManager();
            }
            return instancia;
        }


        public IQueryable<Sucursal> findAllSucursales()
        {
            return db.Sucursals;
        }

        public Sucursal getCategoria(int id)
        {
            return db.Sucursals.SingleOrDefault(c => c.SucursalID == id);
        }

        public void Add(Sucursal sucursal)
        {
            db.Sucursals.InsertOnSubmit(sucursal);
        }

        public void Delete(Sucursal sucursal)
        {
            db.Sucursals.DeleteOnSubmit(sucursal);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
