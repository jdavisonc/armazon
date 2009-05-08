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



namespace Armazon.Models
{
    public class AdministracionFachada
    {
        //Categoria
        public IQueryable<Categoria> findAllCategorias()
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            return categoriaMgr.findAllCategorias();
        }
        public Categoria getCategoria(int num)
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            return categoriaMgr.getCategoria(num);
        }
        public void addCategoria(Categoria Categoria)
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            categoriaMgr.Add(Categoria);
        }
        public void deleteCategoria(int num)
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            categoriaMgr.Delete(categoriaMgr.getCategoria(num));
        }
        public void saveCategoria()
        {
            CategoriaManager categoriaMgr = CategoriaManager.getInstance();
            categoriaMgr.Save();
        }

        //Sucursal
        public IQueryable<Sucursal> findAllSucursales()
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            return sucursalMgr.findAllSucursales();
        }
        public Sucursal getSucursal(int num)
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
        public void saveSucursal()
        {
            SucursalManager sucursalMgr = SucursalManager.getInstance();
            sucursalMgr.Save();
        }
        
        // SubCategoria
        public IQueryable<SubCategoria> findAllSubCategorias()
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            return subCategoriaMgr.findAllSubCategorias();
        }
        public SubCategoria getSubCategoria(int num)
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            return subCategoriaMgr.getSubCategoria(num);
        }

        public void addSubCategoria(SubCategoria subCategoria)
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            subCategoriaMgr.Add(subCategoria);
        }
        public void deleteSubCategoria(int num)
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            subCategoriaMgr.Delete(subCategoriaMgr.getSubCategoria(num));

        }
        public void saveSubCategoria()
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            subCategoriaMgr.Save();
        }

        //Propiedad
        public IQueryable<Propiedad> findAllPropiedades()
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            return propiedadMgr.findAllPropiedades();
        }
        public Propiedad getPropiedad(int num)
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            return propiedadMgr.getPropiedad(num);
        }
        public void addPropiedad(Propiedad propiedad)
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            propiedadMgr.Add(propiedad);
        }
        public void deletePropiedad(int num)
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            propiedadMgr.Delete(propiedadMgr.getPropiedad(num));

        }
        public void savePropiedad()
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            propiedadMgr.Save();
        }

    }
}
