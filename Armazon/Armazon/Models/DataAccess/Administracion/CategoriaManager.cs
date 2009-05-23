using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Armazon;

namespace DatabaseAccess
{
    public class CategoriaManager
    {
        private ArmazonDataContext db;

        public CategoriaManager()
        {
            db = new ArmazonDataContext();
        }


        public IQueryable<Categoria> findAllCategorias()
        {
            return db.Categorias;
        }

        public Categoria getCategoria(int id)
        {
            return db.Categorias.SingleOrDefault(c => c.CategoriaID == id);
        }

        public void Add(Categoria categoria)
        {
            db.Categorias.InsertOnSubmit(categoria);
        }

        public void Delete(Categoria categoria)
        {
            db.Categorias.DeleteOnSubmit(categoria);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}