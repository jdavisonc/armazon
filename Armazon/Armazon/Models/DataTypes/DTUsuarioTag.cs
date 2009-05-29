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

namespace Armazon.Models.DataTypes
{
    public class DTUsuarioTag
    {
        private String usuario;
        public String Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private int cantTags;
        public int CantTags
        {
            get { return cantTags; }
            set { cantTags = value; }
        }
    }
}
