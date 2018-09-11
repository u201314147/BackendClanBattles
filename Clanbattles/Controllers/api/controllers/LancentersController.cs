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
    public class LancentersController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Lancenters
        public IQueryable<Lancenter> GetLancenter()
        {
            return db.Lancenter;
        }

        // GET: api/Lancenters/5
        [ResponseType(typeof(Lancenter))]
        public IHttpActionResult GetLancenter(int id)
        {
            Lancenter lancenter = db.Lancenter.Find(id);
            if (lancenter == null)
            {
                return NotFound();
            }

            return Ok(lancenter);
        }

        //Obtener juegos por LAN CENTER
        // GET: api/Lancenters/5/Games
        [Route("api/Lancenters/{lancenterId}/Games")]
        public IQueryable<Game> GetGamesOfLanCenter(int lancenterId)
        {
            //filtrar con tabla de juegos por lancenter
            var xd = db.Gameperlancenter.Where(x => x.id == lancenterId);

            //variable de lista de juegos vacia
            var xd1 = db.Game.Where(x => x.id == 0);

            for (int i = 0; i < xd.Count(); i++)
            {
                var xd2 = db.Game.Where(x => x.id == xd.ElementAt(i).id_game);

                //agregamos a la lista vacia segun va encontrando
                xd1.Concat(xd2);


            }

            //devolvemos el linq de la lista de juegos de la cabina
            return xd1;
        }

        // PUT: api/Lancenters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLancenter(int id, Lancenter lancenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lancenter.id)
            {
                return BadRequest();
            }

            db.Entry(lancenter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancenterExists(id))
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

        // POST: api/Lancenters
        [ResponseType(typeof(Lancenter))]
        public IHttpActionResult PostLancenter(Lancenter lancenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lancenter.Add(lancenter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lancenter.id }, lancenter);
        }

        // DELETE: api/Lancenters/5
        [ResponseType(typeof(Lancenter))]
        public IHttpActionResult DeleteLancenter(int id)
        {
            Lancenter lancenter = db.Lancenter.Find(id);
            if (lancenter == null)
            {
                return NotFound();
            }

            db.Lancenter.Remove(lancenter);
            db.SaveChanges();

            return Ok(lancenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LancenterExists(int id)
        {
            return db.Lancenter.Count(e => e.id == id) > 0;
        }
    }
}