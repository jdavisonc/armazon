using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

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
                          where cAct.CarritoType == "Activo" && cAct.UsuarioID == user.UsuarioID
                          select cAct;
            return carrito.ToList().First();
        }

        public List<Carrito> getCarritosVendidosAUsuario(int usuarioId)
        {
            var vendido = from vend in db.Carritos
                          where vend.UsuarioID == usuarioId && vend.CarritoType == "Vendido"
                          select vend;
            return vendido.ToList();

        }

        public List<DTUsuarioTag> tagsXUsuario()
        {
            List<DTUsuarioTag> tagsXUsuario = new List<DTUsuarioTag>();
            List<DTUsuarioTag> tagsXUsuarioOrdenado = new List<DTUsuarioTag>();
            IQueryable<Usuario> usuarios = findAllUsuarios();
            foreach (Usuario usuario in usuarios)
            {
                DTUsuarioTag dtut = new DTUsuarioTag();
                dtut.Usuario = usuario.Nombre;
                dtut.CantTags = usuario.Producto_Tags.Count;
                tagsXUsuario.Add(dtut);
            }            
            while (tagsXUsuario.Count > 0){
                DTUsuarioTag max = tagsXUsuario.First();
                foreach (DTUsuarioTag dtut in tagsXUsuario)
                    if (dtut.CantTags > max.CantTags)
                        max = dtut;                           
                tagsXUsuarioOrdenado.Add(max);
                tagsXUsuario.Remove(max);
            }            
            return tagsXUsuarioOrdenado;
        }
        
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
