using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class CarritoManager
    {
        private static CarritoManager instancia = null;
        private ArmazonDataContext db;

        private CarritoManager()
        {
            db = new ArmazonDataContext();
        }

        public static CarritoManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new CarritoManager();
            }
            return instancia;
        }

        /*public IQueryable<Carrito> findAllCarritoVendido()
        {
            return db.Usuarios;
        }

        public IQueryable<Carrito> findAllCarritoVendido()
        {
            return db.Usuarios;
        }
        public Carrito getUsuario(int id)
        {
            return db.Usuarios.SingleOrDefault(c => c.UsuarioID == id);
        }
        
        public Usuario getUsuario(string userName)
        {
            return db.Usuarios.SingleOrDefault(c => c.Nombre == userName);
        }*/

        public void AddCarritoActivo(Activo activo)
        {
            db.Carritos.InsertOnSubmit(activo);
        }
        public Activo getCarritoActivoByUser(int userId)
        {
            var activo = from act in db.Carritos
                         where act is Activo && act.UsuarioID == userId
                         select act;
            if (activo == null)
                return null;
            else
            {
                Activo activoAux = (Activo)activo.ToList().First();
                return activoAux;
            }
        }
        public Activo getCarritoActivoById(int idCarrito)
        {
            var activo = from act in db.Carritos
                         where act is Activo && act.CarritoID == idCarrito
                         select act;
            if (activo == null)
                return null;
            else
            {
                Activo activoAux = (Activo)activo.ToList().First();
                return activoAux;
            }
        }
        /*public void Delete(Usuario usuario)
        {
            db.Usuarios.DeleteOnSubmit(usuario);
        }

        public void Save()
        {
            db.SubmitChanges();
        }*/

    }
}
