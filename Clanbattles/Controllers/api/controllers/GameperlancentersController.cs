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
    public class GameperlancentersController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Gameperlancenters
        public IQueryable<Gameperlancenter> GetGameperlancenter()
        {
            return db.Gameperlancenter;
        }

        // GET: api/Gameperlancenters/5
        [ResponseType(typeof(Gameperlancenter))]
        public IHttpActionResult GetGameperlancenter(int id)
        {
            Gameperlancenter gameperlancenter = db.Gameperlancenter.Find(id);
            if (gameperlancenter == null)
            {
                return NotFound();
            }

            return Ok(gameperlancenter);
        }

        // PUT: api/Gameperlancenters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameperlancenter(int id, Gameperlancenter gameperlancenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameperlancenter.id)
            {
                return BadRequest();
            }

            db.Entry(gameperlancenter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameperlancenterExists(id))
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

        // POST: api/Gameperlancenters
        [ResponseType(typeof(Gameperlancenter))]
        public IHttpActionResult PostGameperlancenter(Gameperlancenter gameperlancenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gameperlancenter.Add(gameperlancenter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gameperlancenter.id }, gameperlancenter);
        }

        // DELETE: api/Gameperlancenters/5
        [ResponseType(typeof(Gameperlancenter))]
        public IHttpActionResult DeleteGameperlancenter(int id)
        {
            Gameperlancenter gameperlancenter = db.Gameperlancenter.Find(id);
            if (gameperlancenter == null)
            {
                return NotFound();
            }

            db.Gameperlancenter.Remove(gameperlancenter);
            db.SaveChanges();

            return Ok(gameperlancenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameperlancenterExists(int id)
        {
            return db.Gameperlancenter.Count(e => e.id == id) > 0;
        }
    }
}