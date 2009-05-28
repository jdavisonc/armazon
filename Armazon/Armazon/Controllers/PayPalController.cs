using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;

using System.IO;
using System.Net;
using System.Text;


namespace Armazon.Controllers
{
    public class PayPalController : Controller
    {
        //
        // GET: /PayPal/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodosDePago = adminFac.findAllMetododePago();
            return View(metodosDePago);

        }

        //
        // GET: /PayPal/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("DetailsTarjeta", pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(pago);
            }
            return null;
        }

        //
        // GET: /PayPal/Create

        public ActionResult Create()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            double precio = adminFac.setearMontoProdComprados();
            ViewData["txtMonto"] = precio;
            return View();
        } 

        //
        // POST: /PayPal/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            string monto = Request.Form["hdnMonto"];
            
              StringBuilder requestString = InitializeRequest("SetExpressCheckout");
              
              requestString.Append("&AMT=" + monto);
              string basePath = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, string.Empty) + Request.ApplicationPath;
              requestString.Append("&RETURNURL="+basePath+"PayPal/"+"PayPalExito");
              requestString.Append("&CANCELURL=" + basePath + "PayPal/" + "PayPalFalla");

              string token;
              string dummy;
              if (Post(requestString.ToString(), out token, out dummy))
                {
                  Session["OrderTotal"] = monto;
                  Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token);
                }
                

            return RedirectToAction("Index");
            
        }







        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Look for the token returned by PayPal
            if (Request.QueryString.Get("token") != null)
            {

                // Initialize the GetExpressCheckoutDetails request string to get
                // credentials and other common parameters
                string token;
                string payerID;
                StringBuilder requestString = InitializeRequest("GetExpressCheckoutDetails");

                // Append the required parameters
                string parameter = "&TOKEN=" + HttpUtility.UrlEncode(Request.QueryString.Get("token"));
                requestString.Append(parameter);

                // Post the request to the API
                if (Post(requestString.ToString(), out token, out payerID))
                {
                    // Initialize the DoExpressCheckoutPayment request string to get
                    // credentials and other common parameters
                    requestString = InitializeRequest("DoExpressCheckoutPayment");

                    // Append the required parameters
                    parameter = "&TOKEN=" + HttpUtility.UrlEncode(token);
                    requestString.Append(parameter);
                    parameter = "&AMT=" + HttpUtility.UrlEncode(decimal.Parse(Session["OrderTotal"].ToString()).ToString("f"));
                    requestString.Append(parameter);
                    parameter = "&PAYMENTACTION=Sale";
                    requestString.Append(parameter);
                    parameter = "&PAYERID=" + HttpUtility.UrlEncode(payerID);
                    requestString.Append(parameter);

                    // Post the request to the API
                    Post(requestString.ToString(), out token, out payerID);
                    

                }
                
            }
        }

        // Initialize the request string to get credentials and other common parameters
        private static StringBuilder InitializeRequest(string method)
        {
            string parameter;
            StringBuilder requestString = new StringBuilder();

            parameter = "METHOD=" + HttpUtility.UrlEncode(method);
            requestString.Append(parameter);
            parameter = "&USER=" + HttpUtility.UrlEncode("mussio_1242266962_biz_api1.hotmail.com");
            requestString.Append(parameter);
            parameter = "&PWD=" + HttpUtility.UrlEncode("1242266974");
            requestString.Append(parameter);
            parameter = "&SIGNATURE=" + HttpUtility.UrlEncode("AiPC9BjkCyDFQXbSkoZcgqH3hpacAWKtVcoSjwXfslWj7lHQAFynLiQG");
            requestString.Append(parameter);
            parameter = "&VERSION=" + HttpUtility.UrlEncode("2.3");
            requestString.Append(parameter);

            return requestString;
        }

        // Create a HttpWebRequest object to post a request to the API
        public bool Post(string request, out string token, out string payerID)
        {
            token = string.Empty;
            payerID = string.Empty;
            HttpWebResponse webResponse;
            try
            {
                // Create request object
                HttpWebRequest webRequest = WebRequest.Create("https://api-3t.sandbox.paypal.com/nvp") as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = request.Length;

                // Write the request string to the request object
                StreamWriter writer = new StreamWriter(webRequest.GetRequestStream());
                writer.Write(request);
                writer.Close();

                // Get the response from the request object and verify the status
                webResponse = webRequest.GetResponse() as HttpWebResponse;
                if (!webRequest.HaveResponse)
                {
                    throw new Exception();
                }
                if (webResponse.StatusCode != HttpStatusCode.OK &&
                    webResponse.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                string test = ex.Message;
                return false;
            }

            // Read the response string
            StreamReader reader = new StreamReader(webResponse.GetResponseStream());
            string responseString = reader.ReadToEnd();
            reader.Close();

            // Parse the response string
            bool success = false;
            char[] ampersand = { '&' };
            string[] pairs = responseString.Split(ampersand);
            char[] equalsign = { '=' };
            for (int i = 0; i < pairs.Length; i++)
            {
                // Find the acknowledgement and other parameters required for subsequent API calls
                string[] pair = pairs[i].Split(equalsign);
                if (pair[0].ToLower() == "ack" && HttpUtility.UrlDecode(pair[1]).ToLower() != "failure")
                {
                    success = true;
                }
                if (pair[0].ToLower() == "token")
                {
                    token = HttpUtility.UrlDecode(pair[1]);
                }
                if (pair[0].ToLower() == "payerid")
                {
                    payerID = HttpUtility.UrlDecode(pair[1]);
                }
            }
            return success;
        }


        public ActionResult PayPalExito()
        {
            return View("PayPalExito");
        }
        public ActionResult PayPalFalla()
        {
            return View("PayPalFalla");
        }
        
        //
        // GET: /PayPal/Edit/5
 
        public ActionResult Edit(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var pago = adminFac.getMetododePago(id);
            if (pago == null)
                return View("NotFoundTarjeta");
            else
            {
                if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("EditTarjeta",pago);
                else
                    if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(pago);
            }
            return null;
        }

        //
        // POST: /PayPal/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AdministracionFachada adminFac = new AdministracionFachada();
                var pago = adminFac.getMetododePago(id);
                if (pago == null)
                    return View("NotFoundTarjeta");
                else
                {
                    if (pago.GetType() == Type.GetType("Armazon.Tarjeta"))
                    {
                        Tarjeta trj = (Tarjeta)adminFac.getMetododePago(id);
                        trj.MetodoDePagoID = pago.MetodoDePagoID;
                        trj.MetodoDePagoType = pago.MetodoDePagoType;
                        trj.Numero = Request.Form["Numero"];
                        adminFac.saveMetodoDePago();
                        return RedirectToAction("Index");

                    }
                    else
                        if (pago.GetType() == Type.GetType("Armazon.PayPal"))
                        {    
                            PayPal ppal = (PayPal)adminFac.getMetododePago(id);
                            ppal.MetodoDePagoID = pago.MetodoDePagoID;
                            ppal.MetodoDePagoType = pago.MetodoDePagoType;
                            adminFac.saveMetodoDePago();
                            return RedirectToAction("Index");           
                        }   
                           
                }
                return null;
    
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodo = adminFac.getMetododePago(id);
            if (metodo == null)
                return View("NotFoundPayPal");
            else
            {
                if (metodo.GetType() == Type.GetType("Armazon.Tarjeta"))
                    return View("DeleteTarjeta", metodo);
                else
                    if (metodo.GetType() == Type.GetType("Armazon.PayPal"))
                        return View(metodo);
            }
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var metodo = adminFac.getMetododePago(id);
            if (metodo == null)
                return View("NotFoundPayPal");
            adminFac.deleteMetodoDePago(metodo);
            adminFac.saveMetodoDePago();
            return RedirectToAction("Index");
        }    

    
    
    
    
    
    }
}
