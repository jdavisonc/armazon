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
using DatabaseAccess;
using Armazon.Models.DataAccess.Administracion;
using Armazon.Models.DataTypes;
using System.Collections.Generic;

namespace Armazon.Models.Fachada.Operativa
{
    public class OperativaFachada
    {
        //Tag
        public IQueryable<Tag> findAllTag()
        {
            TagManager TagMgr = new TagManager();
            return TagMgr.findAllTags();
        }
        public Tag getTag(int id)
        {
            TagManager TagMgr = new TagManager();
            return TagMgr.getTag(id);
        }
        public void addTag(Tag tag)
        {
            TagManager TagMgr = new TagManager();
            TagMgr.Add(tag);
        }
        public void deleteTag(int id)
        {
            TagManager TagMgr = new TagManager();
            TagMgr.Delete(TagMgr.getTag(id));
        }
        public void saveTag()
        {
            TagManager tagMgr = new TagManager();
            tagMgr.Save();
        }

        public List<DTCarrito> ventasTotalesXPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {
            CarritoManager carritoMgr = new CarritoManager();
            return carritoMgr.ventasTotalesXPeriodo(fechaInicio,fechaFin);
        }

		 public List<DTUsuarioTag> tagsXUsuario()
         {
             UsuarioManager usuarioMgr = new UsuarioManager();
             return usuarioMgr.tagsXUsuario();
         }

         public IQueryable<Producto> ProductosMasVendidos(int idSubCategoria)
         {
             
             ProductoManager productoMgr = new ProductoManager();
             return productoMgr.ProductosMasVendidos(idSubCategoria);

         }
    }
}
