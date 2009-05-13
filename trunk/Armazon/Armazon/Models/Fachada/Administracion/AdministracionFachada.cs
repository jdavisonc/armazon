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
        public IQueryable<SubCategoria> findAllSubCategorias(int categoriaID)
        {
            SubCategoriaManager subCategoriaMgr = SubCategoriaManager.getInstance();
            return subCategoriaMgr.findAllSubCategorias(categoriaID);
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
        public IQueryable<Propiedad> propiedadesSubCategoria(int idSubCategoria)
        {
            PropiedadManager propiedadMgr = PropiedadManager.getInstance();
            return propiedadMgr.propiedadesSubCategoria(idSubCategoria);
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
        public Usuario getUsuario(string userName)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            return UsuarioMgr.getUsuario(userName);
        }
        public void addUsuario(Usuario usuario)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            UsuarioMgr.Add(usuario);
        }
        public void deleteUsuario(string userName)
        {
            UsuarioManager UsuarioMgr = UsuarioManager.getInstance();
            UsuarioMgr.Delete(UsuarioMgr.getUsuario(userName));
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
        public Producto getProducto(String nombre)
        {
            ProductoManager productoMgr = ProductoManager.getInstance();
            return productoMgr.getProducto(nombre);
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

        //SubCategoria_Propiedad
        public IQueryable<SubCategoria_Propiedad> findAllSubCategoria_Propiedades()
        {
            SubCategoria_PropiedadManager subCategoria_PropiedadMgr = SubCategoria_PropiedadManager.getInstance();
            return subCategoria_PropiedadMgr.findAllSubCategoria_Propiedades();
        }
        public SubCategoria_Propiedad getSubCategoria_Propiedad(int idSubCategoria, int idPropiedad)
        {
            SubCategoria_PropiedadManager subCategoria_PropiedadMgr = SubCategoria_PropiedadManager.getInstance();
            return subCategoria_PropiedadMgr.getSubCategoria_Propiedad(idSubCategoria, idPropiedad);
        }
        public void addSubCategoria_Propiedad(SubCategoria_Propiedad subCategoria_Propiedad)
        {
            SubCategoria_PropiedadManager subCategoria_PropiedadMgr = SubCategoria_PropiedadManager.getInstance();
            subCategoria_PropiedadMgr.Add(subCategoria_Propiedad);
        }
        public void deleteSubCategoria_Propiedad(int idSubCategoria, int idPropiedad)
        {
            SubCategoria_PropiedadManager subCategoria_PropiedadMgr = SubCategoria_PropiedadManager.getInstance();
            subCategoria_PropiedadMgr.Delete(subCategoria_PropiedadMgr.getSubCategoria_Propiedad(idSubCategoria, idPropiedad));

        }
        public void saveSubCategoria_Propiedad()
        {
            SubCategoria_PropiedadManager subCategoria_PropiedadMgr = SubCategoria_PropiedadManager.getInstance();
            subCategoria_PropiedadMgr.Save();
        }


        //Valor
        public IQueryable<Valor> findAllValores()
        {
            ValorManager valorMgr = ValorManager.getInstance();
            return valorMgr.findAllValores();
        }
        public IQueryable<Valor> valoresProductos(int id)
        {
            ValorManager valorMgr = ValorManager.getInstance();
            return valorMgr.valoresProductos(id);
        }
        public Valor getValor(int idProducto, int idPropiedad)
        {
            ValorManager valorMgr = ValorManager.getInstance();
            return valorMgr.getValor(idProducto, idPropiedad);
        }
        public void addValor(Valor valor)
        {
            ValorManager valorMgr = ValorManager.getInstance();
            valorMgr.Add(valor);
        }
        public void deleteValor(int idProducto, int idPropiedad)
        {
            ValorManager valorMgr = ValorManager.getInstance();
            valorMgr.Delete(valorMgr.getValor(idProducto, idPropiedad));

        }
        public void saveValor()
        {
            ValorManager valorMgr = ValorManager.getInstance();
            valorMgr.Save();
        }
        public IQueryable<MetodoDePago> findAllMetododePago()
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            return mmgr.findAllMetododePago();
        }


        public MetodoDePago getMetododePago(int id)
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            return mmgr.getMetododePago(id);
        }
        public PayPal getMetododePagoPayPal(int id)
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            return mmgr.getMetododePagoPayPal(id);
        }
        public Tarjeta getMetododePagoTarjeta(int id)
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            return mmgr.getMetododePagoTarjeta(id);
        }
        public void AddPayPal(PayPal pago)
        {

            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            mmgr.AddPayPal(pago);
        }
        public void AddTarjeta(Tarjeta tarjeta)
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            mmgr.AddTarjeta(tarjeta);
        }
        public void deleteMetodoDePago(MetodoDePago metodo)
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            mmgr.Delete(metodo);
        }
        public void saveMetodoDePago()
        {
            MetododePagoManager mmgr = MetododePagoManager.getInstance();
            mmgr.Save();
        }
        //Carrito
        public Activo getCarritoActivoByUser(int userId)
        {
            CarritoManager cmgr = CarritoManager.getInstance();
            return cmgr.getCarritoActivoByUser(userId);
        }
        public Activo getCarritoActivoById(int idCarrito)
        {
            CarritoManager cmgr = CarritoManager.getInstance();
            return cmgr.getCarritoActivoById(idCarrito);
        }
    
    }
}
