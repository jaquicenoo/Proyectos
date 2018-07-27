using Newtonsoft.Json;
using PruebaAviones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PruebaAviones.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UsuariosModelo usr)
        {
            HttpResponseMessage response = ApiRest.WebService.PostAsJsonAsync("Usuarios/ValidarUsuario",usr).Result;
            if (response.StatusCode is HttpStatusCode.OK)
            {
                FormsAuthentication.SetAuthCookie(usr.usuario, false);
                TempData["LoginName"] = usr.usuario;
                return RedirectToAction("Index", "Vuelos");
            }
            else
            {
                ViewBag.Message = "usuario o password incorrectos";
                return View("Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            Session.Clear();
            System.Web.HttpContext.Current.Session.RemoveAll();
            return RedirectToAction("Login", "usuarios");
        }
        public ActionResult NuevoUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevoUsuario(UsuariosModelo usr)
        {
            usr.IdUsuarios = Guid.NewGuid();
            string mensaje = "";
            TempData.Remove("Mensaje");
            if(ModelState.IsValid)
            {
                HttpResponseMessage response = ApiRest.WebService.PostAsJsonAsync("Usuarios/PostUsuarios", usr).Result;
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    mensaje = "EL usuario fue creado.";
                    ViewBag.Message = mensaje;
                }
                else
                {
                    mensaje = "El Usuario No pudo ser creado";
                    ViewBag.Message = mensaje;
                }
                return RedirectToAction("Login", "Usuarios");
            }
            else
            {
                mensaje = "El Usuario No pudo ser creado";
                ViewBag.Message = mensaje;
                return RedirectToAction("login", "Usuarios");
            }
        }
    }
}