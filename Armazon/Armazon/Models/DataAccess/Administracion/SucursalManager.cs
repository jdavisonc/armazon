using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace DatabaseAccess
{
    public class SucursalManager
    {
        private ArmazonDataContext db;

        public SucursalManager()
        {
            db = new ArmazonDataContext();
        }

        public IQueryable<Sucursal> findAllSucursales()
        {
            return db.Sucursals;
        }

        public Sucursal getSucursal(int id)
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
