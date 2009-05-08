using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Armazon.Models;
namespace Armazon.Models.DataAccess.Administracion
{
    public class MetododePagoManager
    {
        private static MetododePagoManager instancia = null;
        private ArmazonDataContext db;

        private MetododePagoManager()
        {
            db = new ArmazonDataContext();
            
        }

        public static MetododePagoManager getInstance()
        {
            if (instancia == null)
            {
                instancia = new MetododePagoManager();
            }
            return instancia;
        }


        public IQueryable<MetodoDePago> findAllMetododePago()
        {
            return db.MetodoDePagos;
        }

        public MetodoDePago getMetododePago(int id)
        {
            var metodoPago = db.MetodoDePagos.SingleOrDefault(c => c.MetodoDePagoID == id);
            if (metodoPago != null)
            {
                var paypal = from ppal in db.MetodoDePagos
                             where ppal is PayPal && ppal.MetodoDePagoID == metodoPago.MetodoDePagoID
                             select (PayPal)ppal;


                if (paypal == null)
                {
                    var tarjeta = from card in db.MetodoDePagos
                                  where card is Tarjeta && card.MetodoDePagoID == metodoPago.MetodoDePagoID
                                  select (Tarjeta)card;
                    if (tarjeta == null)
                        return null;
                    else
                        return (Tarjeta)tarjeta;
                }
                return (PayPal)paypal;
            }
            else
                return null;
        }

        public void Add(MetodoDePago pago)
        {
           // db.Sucursals.InsertOnSubmit(pago);
        }


        public void Delete(Sucursal sucursal)
        {
            //db.Sucursals.DeleteOnSubmit(sucursal);
        }

        public void Save()
        {
            db.SubmitChanges();
        }


    }
}
