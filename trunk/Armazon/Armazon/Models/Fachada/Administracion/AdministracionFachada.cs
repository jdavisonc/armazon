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

namespace Armazon.Models
{
    public class AdministracionFachada
    {

        private string userName;
        private string password;
        
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

        //Usuario
        public IQueryable<Usuario> findAllUsuario()
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            return UsuarioMgr.findAllUsuarios();
        }
        public Usuario getUsuario(int num)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            return UsuarioMgr.getUsuario(num);
        }
        public void addUsuario(Usuario usuario)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            UsuarioMgr.Add(usuario);
        }
        public bool validateUsuario(string userName, string password)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            return UsuarioMgr.ValidateUser(userName, password);
        }
        public int getMinPasswordLength()
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            return UsuarioMgr.MinRequiredPasswordLength1;
        }
        public void deleteUsuario(int num)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            UsuarioMgr.Delete(UsuarioMgr.getUsuario(num));
        }
        public void saveUsuario()
        {
            UsuarioManager usuarioMgr = UsuarioManager.getInstance();
            usuarioMgr.Save();
        }




        //Producto
        public IQueryable<Producto> findAllProductos()
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            return productoMgr.findAllProductos();
        }
        public Producto getProducto(int id)
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            return productoMgr.getProducto(id);
        }
        public void addProducto(Producto Producto)
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            productoMgr.Add(Producto);
        }
        public void deleteProducto(int id)
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            productoMgr.Delete(productoMgr.getProducto(id));
        }
        public void saveProducto()
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            productoMgr.Save();
        }

    }
}
