using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class TagManager
    {
        private static TagManager instancia = null;
        private ArmazonDataContext db;

        private TagManager()
        {
            db = new ArmazonDataContext();
            
        }
    }
}
