using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTPedido
    {
        private int id;
        private string nombre;
        private int cant;

        public DTPedido() { }
        public DTPedido(int id)
        {
            this.id = id;
            cant = 0;
        }
        public int Id
        {
            get{return id;}
            set{id = value;}
        }
        public int Cant
        {
            get { return cant; }
            set { cant = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
