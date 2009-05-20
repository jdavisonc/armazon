using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;

namespace Armazon.Controllers
{
    public class ImagenController : Controller
    {
            public ActionResult ShowThumbnail( int id )
            {
                AdministracionFachada adminFach = new AdministracionFachada();
                var imagenData = adminFach.getImagen(id);
                if (imagenData != null)
                    return File(imagenData.Thumbnail.ToArray(), "image/jpg");
                else
                    return null;
            }
            
            public ActionResult Show(int id)
            {
                AdministracionFachada adminFach = new AdministracionFachada();
                var imagenData = adminFach.getImagen(id);
                if (imagenData != null)
                    return File(imagenData.Imagen1.ToArray(), imagenData.MIMEType);
                else
                    return null;
            }
    }
}
