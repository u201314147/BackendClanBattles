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
    public class PublicationsController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Publications
        public IQueryable<Publication> GetPublication()
        {
            return db.Publication;
        }

        // GET: api/Publications/5
        [ResponseType(typeof(Publication))]
        public IHttpActionResult GetPublication(int id)
        {
            Publication publication = db.Publication.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            return Ok(publication);
        }

        // PUT: api/Publications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPublication(int id, Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publication.id)
            {
                return BadRequest();
            }

            db.Entry(publication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/Publications
        [ResponseType(typeof(Publication))]
        public IHttpActionResult PostPublication(Publication publication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Publication.Add(publication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = publication.id }, publication);
        }

        // DELETE: api/Publications/5
        [ResponseType(typeof(Publication))]
        public IHttpActionResult DeletePublication(int id)
        {
            Publication publication = db.Publication.Find(id);
            if (publication == null)
            {
                return NotFound();
            }

            db.Publication.Remove(publication);
            db.SaveChanges();

            return Ok(publication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublicationExists(int id)
        {
            return db.Publication.Count(e => e.id == id) > 0;
        }
    }
}