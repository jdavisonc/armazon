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
using System.Collections.Generic;

namespace Armazon.Models.DataTypes
{
    public class DTCategoria
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private List<DTSubCategoria> subCategorias;

        public List<DTSubCategoria> SubCategorias
        {
            get { return subCategorias; }
            set { subCategorias = value; }
        }

    }
}
