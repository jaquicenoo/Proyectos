using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestVuelos.Models;

namespace RestVuelos.Controllers
{
    public class VuelosController : ApiController
    {
        private PruebaAvionesEntities db = new PruebaAvionesEntities();

        // GET: api/Vuelos
        //public IQueryable<Vuelos> GetVuelos()
        //{
        //    return db.Vuelos;
        //}

        // GET: api/Vuelos/5
        [ResponseType(typeof(GetAllVuelos))]
        public IHttpActionResult GetAllVuelos()
        {
            List<GetAllVuelos> vuelos;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
                vuelos = dbContex.GetAllVuelos.ToList();
            }
            if (vuelos == null)
            {
                return NotFound();
            }

            return Ok(vuelos);
        }
        [ResponseType(typeof(GetAllVuelos))]
        public IHttpActionResult GetVuelo(Guid Id)
        {
            GetAllVuelos vuelos;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
                vuelos = dbContex.GetAllVuelos.Where(X=> X.IdRegistro==Id).FirstOrDefault();
            }
            if (vuelos == null)
            {
                return NotFound();
            }

            return Ok(vuelos);
        }
        [ResponseType(typeof(List<Aerolinea>))]
        public IHttpActionResult GetAllAerolineas()
        {
            List<Aerolinea> Aerolinea;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
               Aerolinea = dbContex.Aerolineas.Select(x=> new Aerolinea {
               NombreAerolinea = x.NombreAerolinea,
               IdAerolinea = x.IdAerolinea
               } ).ToList();              
            }
            if (Aerolinea == null)
            {
                return NotFound();
            }

            return Ok(Aerolinea);
        }
        [ResponseType(typeof(List<Ciudad>))]
        public IHttpActionResult GetAllCiudades()
        {
            List<Ciudad> LAerolinea;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
                LAerolinea = dbContex.Ciudades.Select(x => new Ciudad
                {
                    NombreCiudad = x.NombreCiudad,
                    IdCiudad = x.IdCiudad
                }).ToList();
            }
            if (LAerolinea == null)
            {
                return NotFound();
            }

            return Ok(LAerolinea);
        }
        [ResponseType(typeof(List<Estado>))]
        public IHttpActionResult GetAllEstados()
        {
            List<Estado> LEstados;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
                LEstados = dbContex.Estados.Select(x => new Estado
                {
                    NombreEstado = x.NombreEstado,
                    IdEstado = x.IdEstado
                }).ToList();
            }
            if (LEstados == null)
            {
                return NotFound();
            }

            return Ok(LEstados);
        }
        // PUT: api/Vuelos/5
        [ResponseType(typeof(HttpStatusCode))]
        public IHttpActionResult PutVuelos(Vuelos vuelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(vuelos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Vuelos
        [ResponseType(typeof(Vuelos))]
        public IHttpActionResult PostVuelos(Vuelos vuelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vuelos.Add(vuelos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VuelosExists(vuelos.IdRegistro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vuelos.IdRegistro }, vuelos);
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(Vuelos))]
        public IHttpActionResult DeleteVuelos(Guid id)
        {
            Vuelos vuelos = db.Vuelos.Find(id);
            if (vuelos == null)
            {
                return NotFound();
            }

            db.Vuelos.Remove(vuelos);
            db.SaveChanges();

            return Ok(vuelos);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VuelosExists(Guid id)
        {
            return db.Vuelos.Count(e => e.IdRegistro == id) > 0;
        }
    }
}