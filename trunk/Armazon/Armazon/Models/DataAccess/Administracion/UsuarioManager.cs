using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class UsuarioManager
    {
        private ArmazonDataContext db;

        public UsuarioManager()
        {
            db = new ArmazonDataContext();
        }

        public IQueryable<Usuario> findAllUsuarios()
        {
            return db.Usuarios;
        }

        public Usuario getUsuario(int id)
        {
            return db.Usuarios.SingleOrDefault(c => c.UsuarioID == id);
        }
        
        public Usuario getUsuario(string userName)
        {
            return db.Usuarios.SingleOrDefault(c => c.Nombre == userName);
        }

        public void Add(Usuario usuario)
        {
            db.Usuarios.InsertOnSubmit(usuario);
        }

        public void Delete(Usuario usuario)
        {
            db.Usuarios.DeleteOnSubmit(usuario);
        }

        public Carrito getCarritoOfUser(string userName)
        {
            var usuario = from usr in db.Usuarios
                          where usr.Nombre == userName
                          select usr;
            Usuario user = usuario.ToList().First();
            var carrito = from cAct in db.Carritos
                          where cAct is Activo && cAct.UsuarioID == user.UsuarioID
                          select cAct;
            return carrito.ToList().First();
        }
        
        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
