using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.UI;
using Armazon.Models.DataTypes;
using Armazon.Models;

namespace Armazon
{
    public class MenuController : TemplateControl
    {
        public static List<DTCategoria> getCategorias()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IEnumerable<Categoria> categorias = administracionFachada.findAllCategorias();

            List<DTCategoria> DtCategorias = new List<DTCategoria>();
            foreach (Categoria item in categorias){
                DtCategorias.Add(item.getDataType());
            }
            return DtCategorias;
        }

       

    }
}
