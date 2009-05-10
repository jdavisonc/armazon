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
    public class SubCategoriaManager
    {
        private static SubCategoriaManager instancia = null;
        private ArmazonDataContext db;

        private SubCategoriaManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static SubCategoriaManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new SubCategoriaManager();
            }
            return instancia;
        }


        public IQueryable<SubCategoria> findAllSubCategorias(int categoriaID)
        {
            IQueryable<SubCategoria> subCategorias = (  from sc in db.SubCategorias
                                                        where sc.CategoriaID == categoriaID
                                                        select sc);

            return subCategorias;
        }

        public SubCategoria getSubCategoria(int id)
        {
            return db.SubCategorias.SingleOrDefault(c => c.SubCategoriaID == id);
        }

        public void Add(SubCategoria subCategoria)
        {
            db.SubCategorias.InsertOnSubmit(subCategoria);
        }

        public void Delete(SubCategoria subCategoria)
        {
            db.SubCategorias.DeleteOnSubmit(subCategoria);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

    }
}
