using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class UsuarioManager
    {
        private static UsuarioManager instancia = null;
        private ArmazonDataContext db;

        private UsuarioManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static UsuarioManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new UsuarioManager();
            }
            return instancia;
        }


        public IQueryable<Usuario> findAllUsuarios()
        {
            return db.Usuarios;
        }

        public Usuario getUsuario(int id)
        {
            return db.Usuarios.SingleOrDefault(c => c.UsuarioID == id);
        }

        public void Add(Usuario usuario)
        {
            db.Usuarios.InsertOnSubmit(usuario);
        }

        public void Delete(Usuario usuario)
        {
            db.Usuarios.DeleteOnSubmit(usuario);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
