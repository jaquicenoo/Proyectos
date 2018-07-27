using PruebaAviones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            AuxVUelos model = new AuxVUelos();
            HttpResponseMessage response;
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllAerolineas").Result;
            model.Aerolinea = GetAerolineas(response, "");
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllEstados").Result;
            model.Estados = GetEstados(response, "");
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllCiudades").Result;
            List<Ciudad> Listcidades = response.Content.ReadAsAsync<List<Ciudad>>().Result;
            model.CiudadesOrigen = GetCiudadesOrigen(Listcidades, "");
            model.CiudadesDestino = GetCiudadesDestino(Listcidades, "");
            return View(model);
        }

        [HttpPost]
        public ActionResult NuevoVuelo(AuxVUelos model)
        {
            string message = "";
            VuelosSave vuelo = new VuelosSave();
            if(!ModelState.IsValid)
            {
                message = "El vuelo No pudo ser guardado";
                return RedirectToAction("Index", "Vuelos");
            }
            else
            {
                vuelo.Fecha = model.Fecha;
                vuelo.HoraLlegada = model.HoraLlegada;
                vuelo.HoraSalida = model.HoraSalida;
                vuelo.IdAerolinea = Guid.Parse(model.IdAerolinea);
                vuelo.IdCiudadDestino = Guid.Parse(model.IdCiudadesDestino);
                vuelo.IdCiudadOrigen = Guid.Parse(model.IdciudadOrigen);
                vuelo.IdEstadoVuelo = Int32.Parse(model.IdEstadoVuelo);
                vuelo.IdRegistro = Guid.NewGuid();
                vuelo.NumeroVuelo = model.NumeroVuelo;
                vuelo.TipoVuelo = model.TipoVuelo;
                HttpResponseMessage response = ApiRest.WebService.PostAsJsonAsync("Vuelos/PostVuelos", vuelo).Result;
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    message = "El vuelo se guardo correctamente";
                }
                else
                {
                    message = "El vuelo No pudo ser guardado";
                }
                ViewBag.Message = message;
                return  RedirectToAction("Index", "Vuelos");
            }
        }

        public ActionResult Editar(Guid id)
        {
            ViewBag.Message = "Your application description page.";
            AuxVUelos model = new AuxVUelos();
            HttpResponseMessage response = ApiRest.WebService.GetAsync("Vuelos/GetVuelo/" + id.ToString()).Result;
            VuelosModelo vuelo = response.Content.ReadAsAsync<VuelosModelo>().Result;
            model.IdVuelo = vuelo.IdRegistro;
            model.Fecha = vuelo.Fecha;
            model.HoraLlegada = vuelo.HoraLlegada;
            model.HoraSalida = vuelo.HoraSalida;
            model.NumeroVuelo = vuelo.NumeroVuelo;
            model.TipoVuelo = vuelo.TipoVuelo;
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllAerolineas").Result;
            model.Aerolinea = GetAerolineas(response,vuelo.NombreAerolinea);
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllEstados").Result;
            model.Estados = GetEstados(response, vuelo.NombreEstado);
            response = ApiRest.WebService.GetAsync("Vuelos/GetAllCiudades").Result;
            List<Ciudad>Listcidades= response.Content.ReadAsAsync<List<Ciudad>>().Result;
            model.CiudadesOrigen = GetCiudadesOrigen(Listcidades, vuelo.CiudadOrigen);
            model.CiudadesDestino= GetCiudadesDestino(Listcidades, vuelo.CiudadDestino);
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(AuxVUelos model)
        {
            string message = "";
            VuelosSave vuelo = new VuelosSave();
            if (!ModelState.IsValid)
            {
                message = "El vuelo No pudo ser guardado";
                return RedirectToAction("Index", "Vuelos");
            }
            else
            {
                vuelo.Fecha = model.Fecha;
                vuelo.HoraLlegada = model.HoraLlegada;
                vuelo.HoraSalida = model.HoraSalida;
                vuelo.IdAerolinea = Guid.Parse(model.IdAerolinea);
                vuelo.IdCiudadDestino = Guid.Parse(model.IdCiudadesDestino);
                vuelo.IdCiudadOrigen = Guid.Parse(model.IdciudadOrigen);
                vuelo.IdEstadoVuelo = Int32.Parse(model.IdEstadoVuelo);
                vuelo.IdRegistro = model.IdVuelo;
                vuelo.NumeroVuelo = model.NumeroVuelo;
                vuelo.TipoVuelo = model.TipoVuelo;
                HttpResponseMessage response = ApiRest.WebService.PostAsJsonAsync("Vuelos/PutVuelos", vuelo).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    message = "El vuelo se guardo correctamente";
                }
                else
                {
                    message = "El vuelo No pudo ser guardado";
                }
                ViewBag.Message = message;
                return RedirectToAction("Index", "Vuelos");
            }
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
        public List<SelectListItem> GetEstados(HttpResponseMessage response, String Estado)
        {
            return response.Content.ReadAsAsync<List<Estado>>().Result.Select(X => new SelectListItem
            {
                Text = X.NombreEstado,
                Value = X.IdEstado.ToString(),
                Selected = X.NombreEstado == Estado ? true : false
            }).ToList();

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}