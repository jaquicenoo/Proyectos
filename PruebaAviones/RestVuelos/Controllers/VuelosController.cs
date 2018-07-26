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
        [ResponseType(typeof(VuelosEntrantes))]
        public IHttpActionResult GetVuelosEntrantes()
        {
            List<VuelosEntrantes> vuelos;
            using (PruebaAvionesEntities dbContex = new PruebaAvionesEntities())
            {
                vuelos = dbContex.VuelosEntrantes.ToList();
            }
            if (vuelos == null)
            {
                return NotFound();
            }

            return Ok(vuelos);
        }

        // PUT: api/Vuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVuelos(Guid id, Vuelos vuelos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vuelos.IdRegistro)
            {
                return BadRequest();
            }

            db.Entry(vuelos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VuelosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
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