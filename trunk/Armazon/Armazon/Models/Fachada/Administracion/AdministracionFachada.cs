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



namespace Armazon.Models
{
    public class AdministracionFachada
    {
        public IQueryable<Categoria> findAllCategorias()
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            return categoriaMgr.findAllCategorias();
        }
        public IQueryable<Sucursal> findAllSucursales()
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            return sucursalMgr.findAllSucursales();
        }
        public Sucursal geSucursal(int num)
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            return sucursalMgr.getSucursal(num);
        }

        public void addSucursal(Sucursal sucursal)
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            sucursalMgr.Add(sucursal);
        }
        public void deleteSucursal(int num)
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            sucursalMgr.Delete(sucursalMgr.getSucursal(num));
        
        }
        public void save()
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            sucursalMgr.Save();
        }
    }
}
