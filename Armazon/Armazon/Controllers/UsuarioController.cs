using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Armazon.Models;
using System.Web.Security;
using Armazon.Models.DataAccess.Administracion;
using System.Globalization;
using System.Security.Principal;
namespace Armazon.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            var usuarios = adminFac.findAllUsuario();            
            return View(usuarios);
        }

        //
        // GET: /Usuario/Profile
        public ActionResult Profile()
        {
            AdministracionFachada adminFac = new AdministracionFachada();
            Usuario user = adminFac.getUsuario(User.Identity.Name);
            return View(user);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuario/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            ViewData["PasswordLength"] = adminFach.getMinLargoContrasena();
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions result in password not being changed.")]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            ViewData["PasswordLength"] = adminFach.getMinLargoContrasena();
            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword, adminFach.getMinLargoContrasena()))
            {
                return View();
            }
            try
            {
                if (adminFach.cambiarContrasenaUsuario(User.Identity.Name, currentPassword, newPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                return View();
            }
        }

        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword, int minContrasena)
        {
            if (String.IsNullOrEmpty(currentPassword))
            {
                ModelState.AddModelError("currentPassword", "You must specify a current password.");
            }
            if (newPassword == null || newPassword.Length < minContrasena)
            {
                ModelState.AddModelError("newPassword",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a new password of {0} or more characters.",
                         minContrasena));
            }
            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }
            return ModelState.IsValid;
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {
            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            FormsAuth.SignIn(userName, rememberMe);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidateLogOn(string userName, string password)
        {
            AdministracionFachada adminFa = new AdministracionFachada();
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
            }
            if (!adminFa.validarUsuario(userName, password))
            {
                ModelState.AddModelError("_FORM", "The username or password provided is incorrect.");
            }
            return ModelState.IsValid;
        }

        public ActionResult LogOff()
        {
            FormsAuth.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            ViewData["PasswordLength"] = adminFach.getMinLargoContrasena();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, string email, string password, string confirmPassword)
        {
            AdministracionFachada adminFach = new AdministracionFachada();
            int passLength = adminFach.getMinLargoContrasena();
            ViewData["PasswordLength"] = passLength;

            if (ValidateRegistration(userName, email, password, confirmPassword,passLength))
            {
                try
                {
                    // Attempt to register the user
                    Usuario user = new Usuario();
                    user.Nombre = userName;
                    user.Password = password;
                    // Falta Guardar EMIAL!!
                    adminFach.addUsuario(user);
                    adminFach.saveUsuario();
                    FormsAuth.SignIn(userName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("_FORM", e.Message);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword, int passLength)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", "You must specify a username.");
            }
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email", "You must specify an email address.");
            }
            if (password == null || password.Length < passLength)
            {
                ModelState.AddModelError("password",
                    String.Format(CultureInfo.CurrentCulture,
                         "You must specify a password of {0} or more characters.",
                         passLength));
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", "The new password and confirmation password do not match.");
            }
            return ModelState.IsValid;
        }


        public UsuarioController()
            : this(null)
        {
        }

        public UsuarioController(IFormsAuthentication formsAuth)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationService();
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }

    }

    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public class RequiresRoleAdministratorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = "/Usuario/LogOn" + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
            else
            {
                AdministracionFachada adminFach = new AdministracionFachada();
                Usuario user = adminFach.getUsuario(filterContext.HttpContext.User.Identity.Name);
                if (!user.Administrador)
                {
                    string profile = "/Usuario/Profile";
                    filterContext.HttpContext.Response.Redirect(profile, true);
                }
            }
        }
    }

    public class RequiresLogInAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;
                string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                string loginUrl = "/Usuario/LogOn" + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);
            }
        }
    }

}
