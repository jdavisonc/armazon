﻿using System;
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
using DatabaseAccess;
using Armazon.Models.DataAccess.Administracion;

namespace Armazon.Models.Fachada.Operativa
{
    public class OperativaFachada
    {
        //Tag
        public IQueryable<Tag> findAllTag()
        {
            TagManager TagMgr = TagManager.getInstance();
            return TagMgr.findAllTags();
        }
        public Tag getTag(int id)
        {
            TagManager TagMgr = TagManager.getInstance();
            return TagMgr.getTag(id);
        }
        public void addTag(Tag tag)
        {
            TagManager TagMgr = TagManager.getInstance();
            TagMgr.Add(tag);
        }
        public void deleteTag(int id)
        {
            TagManager TagMgr = TagManager.getInstance();
            TagMgr.Delete(TagMgr.getTag(id));
        }
        public void saveTag()
        {
            TagManager tagMgr = TagManager.getInstance();
            tagMgr.Save();
        }
    }
}
