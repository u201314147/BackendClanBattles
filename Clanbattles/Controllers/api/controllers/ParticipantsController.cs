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
    public class ParticipantsController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Participants
        public IQueryable<Participants> GetParticipants()
        {
            return db.Participants;
        }

        // GET: api/Participants/5
        [ResponseType(typeof(Participants))]
        public IHttpActionResult GetParticipants(int id)
        {
            Participants participants = db.Participants.Find(id);
            if (participants == null)
            {
                return NotFound();
            }

            return Ok(participants);
        }

        // PUT: api/Participants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParticipants(int id, Participants participants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participants.id)
            {
                return BadRequest();
            }

            db.Entry(participants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantsExists(id))
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

        // POST: api/Participants
        [ResponseType(typeof(Participants))]
        public IHttpActionResult PostParticipants(Participants participants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participants.Add(participants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = participants.id }, participants);
        }

        // DELETE: api/Participants/5
        [ResponseType(typeof(Participants))]
        public IHttpActionResult DeleteParticipants(int id)
        {
            Participants participants = db.Participants.Find(id);
            if (participants == null)
            {
                return NotFound();
            }

            db.Participants.Remove(participants);
            db.SaveChanges();

            return Ok(participants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipantsExists(int id)
        {
            return db.Participants.Count(e => e.id == id) > 0;
        }
    }
}