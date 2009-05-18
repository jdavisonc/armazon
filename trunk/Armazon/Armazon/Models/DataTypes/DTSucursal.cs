using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTSucursal
    {
        private string _nombre;
        private double _longitud;
        private string _direccion;
        private double _latitud;
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        
        public DTSucursal()
        {}

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public double Latitud
        {
            get { return _latitud; }
            set { _latitud = value; }
        }

        public double Longitud
        {
            get { return _longitud; }
            set { _longitud = value; }
        }
    }
}
