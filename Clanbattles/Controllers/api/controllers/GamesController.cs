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
    public class GamesController : ApiController
    {
        private ClanModel db = new ClanModel();

        // GET: api/Games
        public IQueryable<Game> GetGame()
        {
            return db.Game;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = db.Game.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
       

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Game.Add(game);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = game.id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = db.Game.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Game.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(int id)
        {
            return db.Game.Count(e => e.id == id) > 0;
        }
    }
}