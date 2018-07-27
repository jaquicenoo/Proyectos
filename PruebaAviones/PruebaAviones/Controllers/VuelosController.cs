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
        [Authorize]
        public ActionResult Index()
        {
            HttpResponseMessage response = ApiRest.WebService.GetAsync("Vuelos/GetAllVuelos").Result;
            List<VuelosModelo> vuelos = response.Content.ReadAsAsync<List<VuelosModelo>>().Result;
            return View(vuelos);
        }
        public ActionResult NuevoVuelo()
        {
            return View();
        }

        //public ActionResult NuevoVuelo(AuxVUelos model)
        //{

        //}

        public ActionResult Editar(Guid id)
        {
            ViewBag.Message = "Your application description page.";
            AuxVUelos model = new AuxVUelos();
            HttpResponseMessage response = ApiRest.WebService.GetAsync("Vuelos/GetVuelo/" + id.ToString()).Result;
            VuelosModelo vuelo = response.Content.ReadAsAsync<VuelosModelo>().Result;
            model.Fecha = vuelo.Fecha;
            model.HoraLlegada = vuelo.HoraLlegada;
            model.HoraSalida = vuelo.HoraSalida;
            model.NumeroVuelo = vuelo.NumeroVuelo;
            model.TipoVuelo = vuelo.TipoVuelo;
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllAerolineas").Result;
            model.Aerolinea = GetAerolineas(response,vuelo.NombreAerolinea);
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllCiudades").Result;
            List<Ciudad>Listcidades= response.Content.ReadAsAsync<List<Ciudad>>().Result;
            model.CiudadesOrigen = GetCiudadesOrigen(Listcidades, vuelo.CiudadOrigen);
            model.CiudadesDestino= GetCiudadesDestino(Listcidades, vuelo.CiudadDestino);
            return View(model);
        }
        public List<SelectListItem> GetCiudadesOrigen(List<Ciudad> Listcidades, String CiudadOrigen)
        {
            return Listcidades.Select(X => new SelectListItem
            {
                Text = X.NombreCiudad,
                Value = X.IdCiudad.ToString(),
                Selected = X.NombreCiudad== CiudadOrigen? true:false
            }).ToList();

        }
        public List<SelectListItem> GetCiudadesDestino(List<Ciudad> Listcidades, String CiudadDestino)
        {
            return Listcidades.Select(X => new SelectListItem
            {
                Text = X.NombreCiudad,
                Value = X.IdCiudad.ToString(),
                Selected = X.NombreCiudad == CiudadDestino ? true : false
            }).ToList();

        }
        public List<SelectListItem> GetAerolineas(HttpResponseMessage response, String Aerolinea)
        {
            return response.Content.ReadAsAsync<List<Aerolinea>>().Result.Select(X => new SelectListItem
            {
                Text = X.NombreAerolinea,
                Value = X.IdAerolinea.ToString(),
                Selected = X.NombreAerolinea == Aerolinea ? true : false
            }).ToList();

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}