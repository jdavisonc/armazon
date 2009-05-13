using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class Map
    {
        public string Name { get; set; }
        public LatLng LatLng { get; set; }
        public int Zoom { get; set; }

        private List<Location> locations = new List<Location>();

        public List<Location> Locations
        {
            get { return locations; }
            set { locations = value; }
        }
    }
}
