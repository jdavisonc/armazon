﻿using System;
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
            return db.Tags;
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
    }
}
