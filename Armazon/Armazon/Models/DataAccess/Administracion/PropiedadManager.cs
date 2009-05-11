using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Armazon.Models.DataAccess.Administracion
{
    public class PropiedadManager
    {
        private static PropiedadManager instancia = null;
        private ArmazonDataContext db;

        private PropiedadManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static PropiedadManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new PropiedadManager();
            }
            return instancia;
        }


        public IQueryable<Propiedad> findAllPropiedades()
        {
            return db.Propiedads;
        }

        public IQueryable<Propiedad> propiedadesSubCategoria(int idSubCategoria)
        {
            var propiedades = (from p in db.Propiedads
                               join sp in db.SubCategoria_Propiedads on p.PropiedadID equals sp.PropiedadID
                               where sp.SubCategoriaID == idSubCategoria
                               select p);
            return propiedades;
        }

        public Propiedad getPropiedad(int id)
        {
            return db.Propiedads.SingleOrDefault(c => c.PropiedadID == id);
        }

        public void Add(Propiedad propiedad)
        {
            db.Propiedads.InsertOnSubmit(propiedad);
        }

        public void Delete(Propiedad propiedad)
        {
            db.Propiedads.DeleteOnSubmit(propiedad);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}

