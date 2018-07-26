using PruebaAviones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PruebaAviones.Controllers
{
    public class VuelosController : Controller
    {
        public ActionResult Index()
        {
            HttpResponseMessage response = ApiRest.WebService.GetAsync("Vuelos/VuelosEntrantes").Result;
            List<VuelosModelo> vuelos = response.Content.ReadAsAsync<List<VuelosModelo>>().Result;
            return View(vuelos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}