using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models.DataTypes;

namespace Armazon
{
    public partial class Sucursal
    {
        #region DataType
        public DTSucursal getDataType()
        {
            DTSucursal dt = new DTSucursal();
            dt.Direccion = this._Direccion;
            dt.Id = this._SucursalID;
            dt.Latitud = this._Latitud;
            dt.Longitud = this._Longitud;
            dt.Nombre = this._Nombre;
            return dt;
        }
        #endregion
    }
}
