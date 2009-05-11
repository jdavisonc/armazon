using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using Armazon.Models;

namespace Armazon.Controllers
{
    public class SubCategoriaController : Controller
    {
        //
        // GET: /SubCategoria/

        public ActionResult Index()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var categorias = administracionFachada.findAllCategorias().ToList();

            return View(categorias);
        }

        //
        // GET: /SubCategoria/ListarSubCategoria/1

        public ActionResult ListarSubCategoria(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var subCategorias = administracionFachada.findAllSubCategorias(id).ToList();

            ViewData["CategoriaID"] = id;
            return View(subCategorias);
        }

        //
        // GET: /SubCategoria/Details/5

        public ActionResult Details(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            SubCategoria subCategoria = administracionFachada.getSubCategoria(id);
            if (subCategoria == null)
                return View("NotFound");
            else
                return View(subCategoria);
        }

        //
        // GET: /Categoria/Create/2

        public ActionResult Create(int id)
        {
            ViewData["CategoriaID"] = id;
            return View();
        }

        //
        // POST: /SubCategoria/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(FormCollection collection)
        {
            SubCategoria subCategoria = new SubCategoria();
            try
            {
                UpdateModel(subCategoria);

                AdministracionFachada administracionFachada = new AdministracionFachada();
                administracionFachada.addSubCategoria(subCategoria);
                administracionFachada.saveSubCategoria();

                return RedirectToAction("ListarSubCategoria", new { id = subCategoria.CategoriaID });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();
            var subCategoria = administracionFachada.getSubCategoria(id);

            return View(subCategoria);
        }

        //
        // POST: /Categoria/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                AdministracionFachada administracionFachada = new AdministracionFachada();
                SubCategoria subCategoria = administracionFachada.getSubCategoria(id);

                subCategoria.Nombre = Request.Form["Nombre"];

                administracionFachada.saveSubCategoria();

                return RedirectToAction("Details", new { id = subCategoria.SubCategoriaID });

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            var subCategoria = administracionFachada.getSubCategoria(id);

            if (subCategoria == null)
            {
                ViewData["CategoriaID"] = int.Parse(Request.Form["CategoriaID"]);
                return View("NotFound");
            }
            else
            {
                return View(subCategoria);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, int categoriaID, string confirmButton)
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            var subCategoria = administracionFachada.getSubCategoria(id);

            ViewData["CategoriaID"] = categoriaID;

            if (subCategoria == null)
            {
                return View("NotFound");
            }

            administracionFachada.deleteSubCategoria(id);
            administracionFachada.saveSubCategoria();

            return View("Deleted");
        }

        //
        // GET: /SubCategoria/AsociarPropiedades/1

        public ActionResult AsociarPropiedades(int id)
        {
            AsociarPropiedadesFormVM form = new AsociarPropiedadesFormVM();
           
            AdministracionFachada administracionFachada = new AdministracionFachada();
            IQueryable<Propiedad> asociadas = administracionFachada.propiedadesSubCategoria(id);
            IQueryable<Propiedad> disponibles = administracionFachada.findAllPropiedades();

            List<Propiedad> lstDisponibles = new List<Propiedad>();

            foreach (Propiedad p in disponibles)
            {
                bool encontre = false;

                foreach (Propiedad pa in asociadas)
                {
                    if (p.PropiedadID == pa.PropiedadID)
                    {
                        encontre = true;
                        break;
                    }
                }
                if (encontre == false)
                {
                    lstDisponibles.Add(p);
                }
            }

            List<Propiedad> lstAsociados = new List<Propiedad>();

            foreach (Propiedad p in asociadas)
            {
                lstAsociados.Add(p);
            }

            form.setSubCategoria(administracionFachada.getSubCategoria(id));
            form.setDisponibles(lstDisponibles);
            form.setAsociadas(lstAsociados);

            return View(form);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AgregarPropiedades()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            int idSubCategoria = int.Parse(Request.Form["hdnIdSubCategoria"]);
            String disponibles = Request.Form["selDisponibles"];
            String[] arrDisponibles = disponibles.Split(',');

            for (int i = 0; i < arrDisponibles.Length; i++)
            {
                String strId = arrDisponibles.ElementAt(i);
                SubCategoria_Propiedad nueva = new SubCategoria_Propiedad();
                nueva.SubCategoriaID = idSubCategoria;
                nueva.PropiedadID = int.Parse(strId);
                nueva.IsIdentificador = 'S';
                administracionFachada.addSubCategoria_Propiedad(nueva);
                administracionFachada.saveSubCategoria_Propiedad();
            }


            AsociarPropiedadesFormVM form = new AsociarPropiedadesFormVM();

            IQueryable<Propiedad> asociadasAnterior = administracionFachada.propiedadesSubCategoria(idSubCategoria);
            IQueryable<Propiedad> todas = administracionFachada.findAllPropiedades();

            List<Propiedad> lstAsociadas = new List<Propiedad>();

            foreach (Propiedad p in asociadasAnterior)
            {
                lstAsociadas.Add(p);
            }

            List<Propiedad> lstDisponibles = new List<Propiedad>();
            foreach (Propiedad p in todas)
            {
                bool encontre = false;

                foreach (Propiedad pa in lstAsociadas)
                {
                    if (p.PropiedadID == pa.PropiedadID)
                    {
                        encontre = true;
                        break;
                    }
                }
                if (encontre == false)
                {
                    lstDisponibles.Add(p);
                }
            }

            form.setSubCategoria(administracionFachada.getSubCategoria(idSubCategoria));
            form.setDisponibles(lstDisponibles);
            form.setAsociadas(lstAsociadas);

            return View("AsociarPropiedades", form);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult QuitarPropiedades()
        {
            AdministracionFachada administracionFachada = new AdministracionFachada();

            int idSubCategoria = int.Parse(Request.Form["hdnIdSubCategoria"]);
            String asociadas = Request.Form["selAsociadas"];
            String[] arrAsociadas = asociadas.Split(',');

            for (int i = 0; i < arrAsociadas.Length; i++)
            {
                String strId = arrAsociadas.ElementAt(i);
                administracionFachada.deleteSubCategoria_Propiedad(idSubCategoria, int.Parse(strId));
                administracionFachada.saveSubCategoria_Propiedad();
            }


            AsociarPropiedadesFormVM form = new AsociarPropiedadesFormVM();

            IQueryable<Propiedad> asociadasAnterior = administracionFachada.propiedadesSubCategoria(idSubCategoria);
            IQueryable<Propiedad> todas = administracionFachada.findAllPropiedades();

            List<Propiedad> lstAsociadas = new List<Propiedad>();

            foreach (Propiedad p in asociadasAnterior)
            {
                lstAsociadas.Add(p);
            }

            List<Propiedad> lstDisponibles = new List<Propiedad>();
            foreach (Propiedad p in todas)
            {
                bool encontre = false;

                foreach (Propiedad pa in lstAsociadas)
                {
                    if (p.PropiedadID == pa.PropiedadID)
                    {
                        encontre = true;
                        break;
                    }
                }
                if (encontre == false)
                {
                    lstDisponibles.Add(p);
                }
            }

            form.setSubCategoria(administracionFachada.getSubCategoria(idSubCategoria));
            form.setDisponibles(lstDisponibles);
            form.setAsociadas(lstAsociadas);

            return View("AsociarPropiedades", form);
        }


    }
}