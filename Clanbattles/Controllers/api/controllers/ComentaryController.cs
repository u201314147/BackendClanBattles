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

namespace Clanbattles.Controllers.api
{
    public class ComentaryController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Comentary
        public IQueryable<Comentarios> GetComentarios()
        {
            return db.Comentarios;
        }

        // GET: api/Comentary/5
        [ResponseType(typeof(Comentarios))]
        public IHttpActionResult GetComentarios(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return NotFound();
            }

            return Ok(comentarios);
        }

        // PUT: api/Comentary/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComentarios(int id, Comentarios comentarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comentarios.id)
            {
                return BadRequest();
            }

            db.Entry(comentarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentariosExists(id))
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

        // POST: api/Comentary
        [ResponseType(typeof(Comentarios))]
        public IHttpActionResult PostComentarios(Comentarios comentarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comentarios.Add(comentarios);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ComentariosExists(comentarios.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = comentarios.id }, comentarios);
        }

        // DELETE: api/Comentary/5
        [ResponseType(typeof(Comentarios))]
        public IHttpActionResult DeleteComentarios(int id)
        {
            Comentarios comentarios = db.Comentarios.Find(id);
            if (comentarios == null)
            {
                return NotFound();
            }

            db.Comentarios.Remove(comentarios);
            db.SaveChanges();

            return Ok(comentarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComentariosExists(int id)
        {
            return db.Comentarios.Count(e => e.id == id) > 0;
        }
    }
}