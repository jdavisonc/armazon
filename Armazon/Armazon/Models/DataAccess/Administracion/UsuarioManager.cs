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
        private int MinRequiredPasswordLength = 6;

        public int MinRequiredPasswordLength1
        {
            get { return MinRequiredPasswordLength; }
            set { MinRequiredPasswordLength = value; }
        }

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

        public bool ValidateUser(string userName, string password)
        {
            var user = from a in db.Usuarios
                       where ((a.Nombre.CompareTo(userName) == 0) && (a.Password.CompareTo(password) == 0))
                       select a;
            return (user != null);
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
