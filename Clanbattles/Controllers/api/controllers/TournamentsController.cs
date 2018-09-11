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
    public class TournamentsController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Tournaments
        public IQueryable<Tournament> GetTournament()
        {
            return db.Tournament;
        }

        // GET: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult GetTournament(int id)
        {
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // PUT: api/Tournaments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTournament(int id, Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tournament.id)
            {
                return BadRequest();
            }

            db.Entry(tournament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult PostTournament(Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tournament.Add(tournament);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tournament.id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public IHttpActionResult DeleteTournament(int id)
        {
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return NotFound();
            }

            db.Tournament.Remove(tournament);
            db.SaveChanges();

            return Ok(tournament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TournamentExists(int id)
        {
            return db.Tournament.Count(e => e.id == id) > 0;
        }
    }
}