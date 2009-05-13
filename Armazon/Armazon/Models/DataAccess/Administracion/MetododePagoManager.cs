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
            return metodoPago;
            /*if (metodoPago != null)
            {
                var paypal = from ppal in db.MetodoDePagos
                             where ppal is PayPal && ppal.MetodoDePagoID == metodoPago.MetodoDePagoID
                             select ppal;


                if (paypal == null)
                {
                    var tarjeta = from card in db.MetodoDePagos
                                  where card is Tarjeta && card.MetodoDePagoID == metodoPago.MetodoDePagoID
                                  select card;
                    if (tarjeta == null)
                        return null;
                    else
                        return tarjeta;
                }
                return paypal;
            }
            else
                return null;*/
        }

        public PayPal getMetododePagoPayPal(int id)
        {
            var metodoPago = db.MetodoDePagos.SingleOrDefault(c => c.MetodoDePagoID == id);
            if (metodoPago != null)
            {
                var paypal = from ppal in db.MetodoDePagos
                             where ppal is PayPal && ppal.MetodoDePagoID == metodoPago.MetodoDePagoID
                             select ppal;

                if (paypal == null)
                    return null;
                else
                {
                    PayPal paypalAux = (PayPal)paypal.ToList().First();
                    return paypalAux;
                }
            }
            else
                return null;
        }
        public Tarjeta getMetododePagoTarjeta(int id)
        {
            var metodoPago = db.MetodoDePagos.SingleOrDefault(c => c.MetodoDePagoID == id);
            if (metodoPago != null)
            {
                var tarjeta = from ppal in db.MetodoDePagos
                             where ppal is Tarjeta && ppal.MetodoDePagoID == metodoPago.MetodoDePagoID
                             select ppal;
                if (tarjeta == null)
                    return null;
                else
                {
                    Tarjeta tarjetaAux = (Tarjeta)tarjeta.ToList().First();
                    return tarjetaAux;
                }
            }
            else
                return null;
        }
        public void AddPayPal(PayPal pago)
        {

            db.MetodoDePagos.InsertOnSubmit(pago);
            db.SubmitChanges();
        }
        public void AddTarjeta(Tarjeta tarjeta)
        {

            db.MetodoDePagos.InsertOnSubmit(tarjeta);
            db.SubmitChanges();
        }

        public void Delete(MetodoDePago metodo)
        {
           
            db.MetodoDePagos.DeleteOnSubmit(metodo);
        }

        public void Save()
        {
            db.SubmitChanges();
        }


    }
}
