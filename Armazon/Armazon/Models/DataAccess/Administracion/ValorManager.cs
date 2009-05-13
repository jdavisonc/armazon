using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace Armazon.Models.DataAccess.Administracion
{
    public class ValorManager
    {
        private static ValorManager instancia = null;
        private ArmazonDataContext db;

        private ValorManager()
        {
            db = new ArmazonDataContext();
        }

        public static ValorManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new ValorManager();
            }
            return instancia;
        }

        public IQueryable<Valor> findAllValores()
        {
            return db.Valors;
        }

        public IQueryable<Valor> valoresProductos(int id)
        {
            var valores = (from Valor v in db.Valors
                           where v.ProductoID == id
                           select v);

            return valores;
        }

        public Valor getValor(int ProductoID, int PropiedadID)
        {
            return db.Valors.SingleOrDefault(c => c.ProductoID==ProductoID && c.PropiedadID==PropiedadID);
        }

        public void Add(Valor valor)
        {
            db.Valors.InsertOnSubmit(valor);                
        }

        public void Delete(Valor valor)
        {
            db.Valors.DeleteOnSubmit(valor);                
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
