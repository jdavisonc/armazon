using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataAccess.Administracion
{
    public class TagManager
    {
        private ArmazonDataContext db;

        public TagManager()
        {
            db = new ArmazonDataContext();            
        }

        public IQueryable<Tag> findAllTags()
        {
            var tags = (from t in db.Tags
                        orderby t.CantAp 
                        select t);
            return tags;
        }

        public Tag getTag(int id)
        {
            return db.Tags.SingleOrDefault(c => c.TagID == id);                
        }

        public Tag getTag(string tag)
        {
            return db.Tags.SingleOrDefault(c => c.Nombre == tag);
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
        public double getSize(String tag) 
        {
            double escala = 0.6;
            double maxCantAp = db.Tags.Max(c => c.CantAp);
            Tag t = getTag(tag);
            if ((0 <= (t.CantAp / maxCantAp)) && ((t.CantAp / maxCantAp) <= 0.1))
                return escala * 1;
            else if ((0.1 <= (t.CantAp / maxCantAp)) && ((t.CantAp / maxCantAp) <= 0.2))
                return escala * 2;
            else if ((0.2 <= (t.CantAp / maxCantAp)) && ((t.CantAp / maxCantAp) <= 0.3))
                return escala * 3;
            else if ((0.3 <= (t.CantAp / maxCantAp)) && ((t.CantAp / maxCantAp) <= 0.4))
                return escala * 4;
            else if (0.4 <= (t.CantAp / maxCantAp) && (t.CantAp / maxCantAp) <= 0.5)
                return escala * 5;
            else if (0.5 <= (t.CantAp / maxCantAp) && (t.CantAp / maxCantAp) <= 0.6)
                return escala * 6;
            else if (0.6 <= (t.CantAp / maxCantAp) && (t.CantAp / maxCantAp) <= 0.7)
                return escala * 7;
            else if (0.7 <= (t.CantAp / maxCantAp) && (t.CantAp / maxCantAp) <= 0.8)
                return escala * 8;
            else if (0.8 <= (t.CantAp / maxCantAp) && (t.CantAp / maxCantAp) <= 0.9)
                return escala * 9;
            else return escala * 10;
        }
    }
}
