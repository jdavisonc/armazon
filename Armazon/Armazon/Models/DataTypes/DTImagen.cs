using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTImagen
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _nombre;
        private string _imagenURL = null;

        public string ImagenURL
        {
            get { return _imagenURL; }
            set { _imagenURL = value; }
        }
        private string _thumbailURL = null;

        public string ThumbailURL
        {
            get { return _thumbailURL; }
            set { _thumbailURL = value; }
        }

        public DTImagen()
        {
        }
        public DTImagen(int id, string nombre, string imagenURL)
        {
            _id = id;
            _nombre = nombre;
            _imagenURL = imagenURL;
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        
    }
}
