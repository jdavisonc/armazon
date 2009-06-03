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
using System.Collections.Generic;
using Armazon.Models.DataTypes;
using Armazon.ArmazonWS;
using Armazon.Models.ServiceAccess;

namespace Armazon.Models
{
    public class AdministracionFachada
    {
        #region Getters y Propiedades

        private CarritoManager _carritoMgr = null;

        public CarritoManager CarritoMgr
        {
            get {
                if (_carritoMgr == null)
                    _carritoMgr = new CarritoManager();
                return _carritoMgr;
            }
        }
        private CategoriaManager _categoriaMgr = null;

        public CategoriaManager CategoriaMgr
        {
            get {
                if (_categoriaMgr == null)
                    _categoriaMgr = new CategoriaManager();
                return _categoriaMgr; 
            }
        }
        private ImagenManager _imagenMgr = null;

        public ImagenManager ImagenMgr
        {
            get {
                if (_imagenMgr == null)
                    _imagenMgr = new ImagenManager();
                return _imagenMgr; 
            }
        }
        private MetododePagoManager _metodoPagoMgr = null;

        public MetododePagoManager MetodoPagoMgr
        {
            get {
                if (_metodoPagoMgr == null)
                    _metodoPagoMgr = new MetododePagoManager();
                return _metodoPagoMgr; 
            }
        }
        private Producto_TagManager _productoTagMgr = null;

        public Producto_TagManager ProductoTagMgr
        {
            get {
                if (_productoTagMgr == null)
                    _productoTagMgr = new Producto_TagManager();
                return _productoTagMgr;
            }
        }
        private PropiedadManager _propiedadMgr = null;

        public PropiedadManager PropiedadMgr
        {
            get {
                if (_propiedadMgr == null)
                    _propiedadMgr = new PropiedadManager();
                return _propiedadMgr; }
        }
        private ProductoManager _productoMgr = null;

        public ProductoManager ProductoMgr
        {
            get {
                if (_productoMgr == null)
                    _productoMgr = new ProductoManager();
                return _productoMgr; 
            }
        }
        private SubCategoria_PropiedadManager _subcategoriaPropiedadMgr = null;

        public SubCategoria_PropiedadManager SubcategoriaPropiedadMgr
        {
            get {
                if (_subcategoriaPropiedadMgr == null)
                    _subcategoriaPropiedadMgr = new SubCategoria_PropiedadManager();
                return _subcategoriaPropiedadMgr; 
            }
        }
        private SubCategoriaManager _subcategoriaMgr = null;

        public SubCategoriaManager SubcategoriaMgr
        {
            get {
                if (_subcategoriaMgr == null)
                    _subcategoriaMgr = new SubCategoriaManager();
                return _subcategoriaMgr; 
            }
        }
        private SucursalManager _sucursalMgr = null;

        public SucursalManager SucursalMgr
        {
            get {
                if (_sucursalMgr == null)
                    _sucursalMgr = new SucursalManager();
                return _sucursalMgr; 
            }
        }
        private TagManager _tagMgr = null;

        public TagManager TagMgr
        {
            get {
                if (_tagMgr == null)
                    _tagMgr = new TagManager();
                return _tagMgr; 
            }
        }
        private TiendaManager _tiendaMgr = null;

        public TiendaManager TiendaMgr
        {
            get {
                if (_tiendaMgr == null)
                    _tiendaMgr = new TiendaManager();
                return _tiendaMgr; 
            }
        }
        private UsuarioManager _usuarioMgr = null;

        public UsuarioManager UsuarioMgr
        {
            get {
                if (_usuarioMgr == null)
                    _usuarioMgr = new UsuarioManager();
                return _usuarioMgr; 
            }
        }
        private ValorManager _valorMgr = null;

        public ValorManager ValorMgr
        {
            get {
                if (_valorMgr == null)
                    _valorMgr = new ValorManager();
                return _valorMgr; 
            }
        }

#endregion

        #region Categoria
        public IQueryable<Categoria> findAllCategorias()
        {
            return CategoriaMgr.findAllCategorias();
        }
        public Categoria getCategoria(int num)
        {
            return CategoriaMgr.getCategoria(num);
        }
        public void addCategoria(Categoria Categoria)
        {
            CategoriaMgr.Add(Categoria);
        }
        public void deleteCategoria(int num)
        {
            CategoriaMgr.Delete(CategoriaMgr.getCategoria(num));
        }
        public void saveCategoria()
        {
            CategoriaMgr.Save();
        }
        #endregion

        #region Sucursal
        public IQueryable<Sucursal> findAllSucursales()
        {
            return SucursalMgr.findAllSucursales();
        }
        public Sucursal getSucursal(int num)
        {
            return SucursalMgr.getSucursal(num);
        }

        public void addSucursal(Sucursal sucursal)
        {
            SucursalMgr.Add(sucursal);
        }
        public void deleteSucursal(int num)
        {
            SucursalMgr.Delete(SucursalMgr.getSucursal(num));
        }
        public void saveSucursal()
        {
            SucursalMgr.Save();
        }
        #endregion

        #region SubCategoria
        public IQueryable<SubCategoria> findAllSubCategorias(int categoriaID)
        {
            return SubcategoriaMgr.findAllSubCategorias(categoriaID);
        }
        public SubCategoria getSubCategoria(int num)
        {
            return SubcategoriaMgr.getSubCategoria(num);
        }

        public void addSubCategoria(SubCategoria subCategoria)
        {
            SubcategoriaMgr.Add(subCategoria);
        }
        public void deleteSubCategoria(int num)
        {
            SubcategoriaMgr.Delete(SubcategoriaMgr.getSubCategoria(num));

        }
        public void saveSubCategoria()
        {
            SubcategoriaMgr.Save();
        }
        #endregion

        #region Propiedad
        public IQueryable<Propiedad> findAllPropiedades()
        {
            return PropiedadMgr.findAllPropiedades();
        }
        public IQueryable<Propiedad> propiedadesSubCategoria(int idSubCategoria)
        {
            return PropiedadMgr.propiedadesSubCategoria(idSubCategoria);
        }
        public Propiedad getPropiedad(int num)
        {
            return PropiedadMgr.getPropiedad(num);
        }
        public void addPropiedad(Propiedad propiedad)
        {
            PropiedadMgr.Add(propiedad);
        }
        public void deletePropiedad(int num)
        {
            PropiedadMgr.Delete(PropiedadMgr.getPropiedad(num));
        }
        public void savePropiedad()
        {
            PropiedadMgr.Save();
        }
        #endregion

        #region Usuario
        public IQueryable<Usuario> findAllUsuario()
        {
            return UsuarioMgr.findAllUsuarios();
        }
        public Usuario getUsuario(int num)
        {
            return UsuarioMgr.getUsuario(num);
        }
        public Usuario getUsuario(string userName)
        {
            return UsuarioMgr.getUsuario(userName);
        }
        public void addUsuario(Usuario usuario)
        {
            UsuarioMgr.Add(usuario);
        }
        public void deleteUsuario(string userName)
        {
            UsuarioMgr.Delete(UsuarioMgr.getUsuario(userName));
        }
        public Usuario getUserSession()
        {
            MembershipUser myObject = Membership.GetUser();
            if (myObject == null)
            {
                return null;
            }
            else
            {
                string userName = myObject.UserName.ToString();
                return getUsuario(userName);
            }
        }
        public void saveUsuario()
        {
            UsuarioMgr.Save();
        }
        public Carrito getCarritoOfUser(string userName)
        {
            return UsuarioMgr.getCarritoOfUser(userName);
        }
        public List<Carrito> getCarritosVendidosAUsuario()
        {
            Usuario usr =  getUserSession();
            return UsuarioMgr.getCarritosVendidosAUsuario(usr.UsuarioID);
        }
        public List<Producto> getProductosComentables(List<Carrito> carritos)
        {
            Usuario usr = getUserSession();
            List<Producto> lprod = new List<Producto>();
            foreach (Carrito aux in carritos)
            {
                List<Producto_Carrito> listProdCarrito = CarritoMgr.getProductosConfirmados(aux.CarritoID);
                 
                foreach (Producto_Carrito pcarrito in listProdCarrito)
                { 
                    
                    //var prodUusario = from prodUsr in DBConcurrencyException. Producto_Usuario
                    bool comentado = ProductoMgr.estaComentado(pcarrito.ProductoID, usr.UsuarioID);
                    if (!comentado)
                        lprod.Add(ProductoMgr.getProducto(pcarrito.ProductoID));
                }
            }
            return lprod;
        }
        public void getProductosDeOtraTienda()
        {
            List<Carrito> carritosVendidos = getCarritosVendidosAUsuario();
            List<DTPedido> productos = new List<DTPedido>();
            List<Tienda> ltiendas  = TiendaMgr.findAllTiendas().ToList();
            foreach (Carrito aux in carritosVendidos)
            {
                 
           }
        }


        #endregion

        #region Producto
        public IQueryable<Producto> findAllProductos()
        {
            return ProductoMgr.findAllProductos();
        }
        public Producto getProducto(int id)
        {
            return ProductoMgr.getProducto(id);
        }
        public Producto getProducto(String nombre)
        {
            return ProductoMgr.getProducto(nombre);
        }
        public void addProducto(Producto Producto)
        {
            ProductoMgr.Add(Producto);
        }
        public void deleteProducto(int id)
        {
            ProductoMgr.Delete(ProductoMgr.getProducto(id));
        }
        public void saveProducto()
        {
            ProductoMgr.Save();
        }
        public double getMontoProductos(List<DTPedido> listProd)
        {
            double monto =  ProductoMgr.getMontoProductos(listProd);
            AdministracionFachada adminFac = new AdministracionFachada();
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = adminFac.getCarritoOfUser(userName);
            carrito.Total = monto;
            return monto;
        }
        public double getMontoCarritoActivo()
        {
            Usuario usr = getUserSession();
            Carrito activo = getCarritoActivoByUser(usr.UsuarioID);
            List<DTPedido> listProd = getProductosDeCarrito(activo.CarritoID);
            return getMontoProductos(listProd);
        }
        public double setearMontoProdComprados()
        {
            MembershipUser myObject = Membership.GetUser();
            string userName = myObject.UserName.ToString();
            Carrito carrito = UsuarioMgr.getCarritoOfUser(userName);
            List<Producto_Carrito> listProdCarrito =  CarritoMgr.getProductosConfirmados(carrito.CarritoID);

            double monto = 0;
            foreach (Producto_Carrito auxprodCarr in listProdCarrito)
            {
                monto = ProductoMgr.getProducto(auxprodCarr.ProductoID).Precio * auxprodCarr.Cantidad + monto;

            }
            carrito.Fecha = DateTime.Now;
            carrito.Total = float.Parse("12");
            CarritoMgr.Save();
            return monto;
        }
        public void deleteProducto_Carrito(int idProd, int idCarro)
        {
            CarritoMgr.deleteProducto_Carrito(idProd, idCarro);
        }

        public void marcarProductosDelCarro(int idCarro) 
        {
            CarritoMgr.marcarProductosDelCarro(idCarro);
        }
        public List<string> getNombresProductos(List<Producto> listProd)
        {
            return ProductoMgr.getNombresProductos(listProd);
        }

        
        #endregion

        #region SubCategoria_Propiedad
        public IQueryable<SubCategoria_Propiedad> findAllSubCategoria_Propiedades()
        {
            return SubcategoriaPropiedadMgr.findAllSubCategoria_Propiedades();
        }
        public SubCategoria_Propiedad getSubCategoria_Propiedad(int idSubCategoria, int idPropiedad)
        {
            return SubcategoriaPropiedadMgr.getSubCategoria_Propiedad(idSubCategoria, idPropiedad);
        }
        public void addSubCategoria_Propiedad(SubCategoria_Propiedad subCategoria_Propiedad)
        {
            SubcategoriaPropiedadMgr.Add(subCategoria_Propiedad);
        }
        public void deleteSubCategoria_Propiedad(int idSubCategoria, int idPropiedad)
        {
            SubcategoriaPropiedadMgr.Delete(SubcategoriaPropiedadMgr.getSubCategoria_Propiedad(idSubCategoria, idPropiedad));
        }
        public void saveSubCategoria_Propiedad()
        {
            SubcategoriaPropiedadMgr.Save();
        }
        #endregion

        #region Valor
        public IQueryable<Valor> findAllValores()
        {
            return ValorMgr.findAllValores();
        }
        public IQueryable<Valor> valoresProductos(int id)
        {
            return ValorMgr.valoresProductos(id);
        }
        public Valor getValor(int idProducto, int idPropiedad)
        {
            return ValorMgr.getValor(idProducto, idPropiedad);
        }
        public void addValor(Valor valor)
        {
            ValorMgr.Add(valor);
        }
        public void deleteValor(int idProducto, int idPropiedad)
        {
            ValorMgr.Delete(ValorMgr.getValor(idProducto, idPropiedad));
        }
        public void saveValor()
        {
            ValorMgr.Save();
        }
        #endregion

        #region Metodos de pago
        public IQueryable<MetodoDePago> findAllMetododePago()
        {
            return MetodoPagoMgr.findAllMetododePago();
        }

        public MetodoDePago getMetododePago(int id)
        {
            return MetodoPagoMgr.getMetododePago(id);
        }
        public PayPal getMetododePagoPayPal(int id)
        {
            return MetodoPagoMgr.getMetododePagoPayPal(id);
        }
        public Tarjeta getMetododePagoTarjeta(int id)
        {
            return MetodoPagoMgr.getMetododePagoTarjeta(id);
        }
        public void AddPayPal(PayPal pago)
        {
            MetodoPagoMgr.AddPayPal(pago);
        }
        public void AddTarjeta(Tarjeta tarjeta)
        {
            MetodoPagoMgr.AddTarjeta(tarjeta);
        }
        public void deleteMetodoDePago(MetodoDePago metodo)
        {
            MetodoPagoMgr.Delete(metodo);
        }
        public void saveMetodoDePago()
        {
            MetodoPagoMgr.Save();
        }
        public List<Tarjeta> getUsuarioTarjetas(int idUsuario)
        { 
            return MetodoPagoMgr.getUsuarioTarjetas(idUsuario);
        }
        
        #endregion
        
        #region Carrito
        public void AddCarritoActivo(Carrito activo)
        {
            CarritoMgr.AddCarritoActivo(activo);
        }
        public Carrito getCarritoActivoByUser(int userId)
        {
            return CarritoMgr.getCarritoActivoByUser(userId);
        }
        public Carrito getCarrito(int idCarrito)
        {
            return CarritoMgr.getCarrito(idCarrito);
        }
        public Carrito getCarritoActivoById(int idCarrito)
        {
            return CarritoMgr.getCarritoActivoById(idCarrito);
        }
        public void AgregarProductoCarrito(int productoId, int carritoId,int cant)
        {
            CarritoMgr.AgregarProductoCarrito(productoId, carritoId, cant);
        }
        public List<DTPedido> getProductosDeCarrito(int carrito)
        {
            return CarritoMgr.getProductosDeCarrito(carrito);
        }

        public void cambiarCantidadProducto(int productoId, int carritoId, int cant)
        {
            CarritoMgr.cambiarCantidadProducto(productoId, carritoId, cant);
        }
        public DTCarroVendido finalizarVentaCarrito(int carritoId)
        {

            DTCarroVendido dtcv = CarritoMgr.finalizarVentaCarrito(carritoId);
            Carrito vendido = getCarrito(carritoId);
            List<DTPedido> productos = CarritoMgr.getProductosDeCarrito(vendido.CarritoID);
            List<Tienda> ltiendas = TiendaMgr.findAllTiendas().ToList();
            foreach (Tienda auxTienda in ltiendas)
            {
                List<DCCartItem> lprod = new List<DCCartItem>();
                foreach (DTPedido dtp in productos)
                {
                    Producto prod = getProducto(dtp.Id);

                    if (prod.TiendaID != null && prod.TiendaID == auxTienda.TiendaID)
                    {
                        DCCartItem dtci = new DCCartItem();
                        dtci.ProductId = int.Parse(prod.ExternalID);
                        dtci.Quantity = dtp.Cant;
                        lprod.Add(dtci);

                    }
                }
                if (lprod.Count != 0)
                {
                    IAccessStore iservicios = FabricAccessStore.getInstance().createArmazonServiceAccess();
                    iservicios.cartBuy(lprod, auxTienda);
                }
            }
            return dtcv;
        }            
        public void SaveCarritoActivo()
        {
            CarritoMgr.Save();
        }
        #endregion

        #region  Tags
        public IQueryable<Tag> findAllTags()
        {
            return TagMgr.findAllTags();
        }

        public Tag getTag(string tag)
        {
            return TagMgr.getTag(tag);
        }

        public void AddTag(Tag tag)
        {
            TagMgr.Add(tag);
        }

        public void DeleteTag(Tag tag)
        {
            TagMgr.Delete(tag);
        }

        public void SaveTags()
        {
            TagMgr.Save();
        }
        public double getSizeTag(String tag)
        {
            return TagMgr.getSize(tag);
        }
        #endregion

        #region  producto_Tag
        public IQueryable<Producto_Tag> findAllProducto_Tags()
        {
            return ProductoTagMgr.findAllProducto_Tags();
        }

        public Producto_Tag getProducto_Tag(int productoID, int tagID)
        {
            return ProductoTagMgr.getProducto_Tag(productoID, tagID);
        }

        public void AddProducto_Tag(Producto_Tag producto_tag)
        {
            ProductoTagMgr.Add(producto_tag);
        }

        public void DeleteProducto_Tag(Producto_Tag producto_Tag)
        {
            ProductoTagMgr.Delete(producto_Tag);
        }

        public void SaveProducto_Tag()
        {
            ProductoTagMgr.Save();
        }
        #endregion

        #region Tienda
        public IQueryable<Tienda> findAllTiendas()
        {
            return TiendaMgr.findAllTiendas();
        }
        public Tienda getTienda(int id)
        {
            return TiendaMgr.getTienda(id);
        }
        public void addTienda(Tienda tienda)
        {
            TiendaMgr.Add(tienda);
        }
        public void deleteTienda(int id)
        {
            TiendaMgr.Delete(TiendaMgr.getTienda(id));
        }
        public void saveTienda()
        {
            TiendaMgr.Save();
        }
        #endregion
        
        #region imagen
        public void addImagen(Imagen img)
        {
            ImagenMgr.addImagen(img);
        }
        public Imagen getImagen(int id)
        {
            return ImagenMgr.getImagen(id);
        }
        public void deleteImagen(int id)
        {
            ImagenMgr.DeleteImagen(id);
        }
        public void saveImagen()
        {
            ImagenMgr.Save();
        }
        #endregion
    }
}
