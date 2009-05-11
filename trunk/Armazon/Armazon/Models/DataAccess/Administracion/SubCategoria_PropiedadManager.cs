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
    public class SubCategoria_PropiedadManager
    {
        private static SubCategoria_PropiedadManager instancia = null;
        private ArmazonDataContext db;

        private SubCategoria_PropiedadManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static SubCategoria_PropiedadManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new SubCategoria_PropiedadManager();
            }
            return instancia;
        }


        public IQueryable<SubCategoria_Propiedad> findAllSubCategoria_Propiedades()
        {
            return db.SubCategoria_Propiedads;
        }

        public SubCategoria_Propiedad getSubCategoria_Propiedad(int idSubCategoria, int idPropiedad)
        {
            return db.SubCategoria_Propiedads.SingleOrDefault(c => c.PropiedadID == idPropiedad && c.SubCategoriaID == idSubCategoria);
        }

        public void Add(SubCategoria_Propiedad subCategoria_Propiedad)
        {
            db.SubCategoria_Propiedads.InsertOnSubmit(subCategoria_Propiedad);
        }

        public void Delete(SubCategoria_Propiedad subCategoria_Propiedad)
        {
            db.SubCategoria_Propiedads.DeleteOnSubmit(subCategoria_Propiedad);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}


