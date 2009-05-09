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

        public static TagManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new TagManager();
            }
            return instancia;
        }

        public IQueryable<Tag> findAllTags()
        {
            return db.Tags;
        }

        public Tag getTag(int id)
        {
            return db.Tags.SingleOrDefault(c => c.TagID == id);                
        }

        public void Add(Tag tag)
        {
            db.Tags.InsertOnSubmit(tag);
        }

        public void Delete(Tag tag)
        {
            db.Tags.DeleteOnSubmit(tag);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
