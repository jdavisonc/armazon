using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class Location
    {
        public string Name { get; set; }
        public LatLng LatLng { get; set; }
        public string Address { get; set; }
    }
}
