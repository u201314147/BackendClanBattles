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
using Clanbattles.Controllers.api;

namespace Clanbattles.Controllers.api.controllers
{
    public class VersusController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Versus
        public IQueryable<Versus> GetVersus()
        {
            return db.Versus;
        }

        // GET: api/Versus/5
        [ResponseType(typeof(Versus))]
        public IHttpActionResult GetVersus(int id)
        {
            Versus versus = db.Versus.Find(id);
            if (versus == null)
            {
                return NotFound();
            }

            return Ok(versus);
        }

        // PUT: api/Versus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVersus(int id, Versus versus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != versus.id)
            {
                return BadRequest();
            }

            db.Entry(versus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersusExists(id))
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

        // POST: api/Versus
        [ResponseType(typeof(Versus))]
        public IHttpActionResult PostVersus(Versus versus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Versus.Add(versus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = versus.id }, versus);
        }

        // DELETE: api/Versus/5
        [ResponseType(typeof(Versus))]
        public IHttpActionResult DeleteVersus(int id)
        {
            Versus versus = db.Versus.Find(id);
            if (versus == null)
            {
                return NotFound();
            }

            db.Versus.Remove(versus);
            db.SaveChanges();

            return Ok(versus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VersusExists(int id)
        {
            return db.Versus.Count(e => e.id == id) > 0;
        }
    }
}