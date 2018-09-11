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
    public class GamersController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Gamers
        public IQueryable<Gamer> GetGamer()
        {
            return db.Gamer;
        }

        // GET: api/Gamers/5
        [ResponseType(typeof(Gamer))]
        public IHttpActionResult GetGamer(int id)
        {
            Gamer gamer = db.Gamer.Find(id);
            if (gamer == null)
            {
                return NotFound();
            }

            return Ok(gamer);
        }

        // PUT: api/Gamers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGamer(int id, Gamer gamer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gamer.id)
            {
                return BadRequest();
            }

            db.Entry(gamer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamerExists(id))
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

        // POST: api/Gamers
        [ResponseType(typeof(Gamer))]
        public IHttpActionResult PostGamer(Gamer gamer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gamer.Add(gamer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gamer.id }, gamer);
        }

        // DELETE: api/Gamers/5
        [ResponseType(typeof(Gamer))]
        public IHttpActionResult DeleteGamer(int id)
        {
            Gamer gamer = db.Gamer.Find(id);
            if (gamer == null)
            {
                return NotFound();
            }

            db.Gamer.Remove(gamer);
            db.SaveChanges();

            return Ok(gamer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GamerExists(int id)
        {
            return db.Gamer.Count(e => e.id == id) > 0;
        }
    }
}