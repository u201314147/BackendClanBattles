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
using ClanBattlesService.Models;
using System.Dynamic;
using ClanBattlesService.Dtos;
using AutoMapper;
using ClanBattlesService.Dtos.Info;

namespace ClanBattlesService.Controllers.ClanBattlesApi
{
    public class LanCentersController : ApiController
    {

        private ClanBattlesEntities _context;
        private string EntityName = "LanCenter";

        public LanCentersController()
        {
            _context = new ClanBattlesEntities();
        }

        [HttpGet]
        [Route("clanbattles/v1/lancenters")]
        public IHttpActionResult GetLanCenters()
        {

            dynamic Response = new ExpandoObject();
            try
            {
                Response.Status = ConstantValues.ResponseStatus.OK;
                var LanCenter = _context.LanCenters.ToList();
                Response.LanCenters = LanCenter.Select(Mapper.Map<LanCenter, LanCenterDto>);
                return Ok(Response);
            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }

        [HttpGet]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}")]
        public IHttpActionResult GetLanCenter(int lancenterid)
        {

            dynamic Response = new ExpandoObject();
            try
            {
                var lancenter = _context.LanCenters.FirstOrDefault(l => l.id == lancenterid);
                if (lancenter == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, lancenterid);
                    return Content(HttpStatusCode.NotFound, Response);
                }
                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.LanCenter = Mapper.Map<LanCenter, LanCenterDto>(lancenter);
                return Ok(Response);
            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }



        [HttpGet]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/reservations")]
        public IHttpActionResult GetReservationsByLanCenter(int lancenterid)
        {
            dynamic Response = new ExpandoObject();

            try
            {
                Response.Status = ConstantValues.ResponseStatus.OK;
                var reservations = _context.Reservations.Where(r => r.lanCenterId == lancenterid).ToList();

                Response.Reservations = reservations.Select(Mapper.Map<Reservation, ReservationInfo>);
                return Ok(Response);
            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }


        [HttpGet]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/reservations/{reservationid:int}")]
        public IHttpActionResult GetReservationByLanCenter(int lancenterid, int reservationid)
        {
            EntityName = "Reservation";
            dynamic Response = new ExpandoObject();

            try
            {
                var reservation = _context.Reservations.FirstOrDefault(r => r.id == reservationid);

                if (reservation == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, reservationid);
                    return Content(HttpStatusCode.NotFound, Response);
                }

                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.Reservation = Mapper.Map<Reservation, ReservationInfo>(reservation);
                return Ok(Response);

            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }


        [HttpPut]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/reservations/{reservationid:int}")]
        public IHttpActionResult UpdateReservationByLanCenter(int lancenterid, int reservationid, [FromBody] ReservationDto reservationdto)
        {
            EntityName = "Reservation";

            dynamic Response = new ExpandoObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = ConstantValues.ErrorMessage.BAD_REQUEST;
                    return Content(HttpStatusCode.BadRequest, Response);
                }

                var reservation = _context.Reservations.SingleOrDefault(r => r.id == reservationid);

                if (reservation == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, reservationid);
                    return Content(HttpStatusCode.NotFound, Response);
                }
                reservationdto.lanCenterId = lancenterid;
                Mapper.Map(reservationdto, reservation);
                _context.SaveChanges();

                reservationdto.id = reservation.id;
                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.Reservation = reservationdto;
                return Ok(Response);

            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }


        [HttpDelete]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/reservations/{reservationid:int}")]
        public IHttpActionResult DeleteReservationByLanCenter(int lancenterid, int reservationid)
        {
            EntityName = "Reservation";
            dynamic Response = new ExpandoObject();

            try
            {
                var reservation = _context.Reservations.FirstOrDefault(r => r.id == reservationid);

                if (reservation == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, reservationid);
                    return Content(HttpStatusCode.NotFound, Response);
                }

                reservation.status = ConstantValues.EntityStatus.INACTIVE;
                _context.SaveChanges();

                Response.Status = ConstantValues.ResponseStatus.OK;

                return Ok(Response);

            }
            catch
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }

        [HttpGet]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/tournaments")]
        public IHttpActionResult GetTournamentsByLanCenter(int lancenterid, [FromUri]int? gameid = null)
        {
            dynamic Response = new ExpandoObject();

            try
            {
                Response.Status = ConstantValues.ResponseStatus.OK;

                var tournaments = _context.Tournaments.Where(t => t.lanCenterId == lancenterid).ToList();

                if (gameid.HasValue)
                {
                    tournaments = _context.Tournaments.Where(t => t.lanCenterId == lancenterid && t.gameId == gameid).ToList();
                }

                Response.Tournaments = tournaments.Select(Mapper.Map<Tournament, TournamentDto>);
                return Ok(Response);
            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }

        [HttpGet]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/tournaments/{tournamentid:int}")]
        public IHttpActionResult GetTournamentByLanCenter(int lancenterid, int tournamentid)
        {
            EntityName = "Tournament";
            dynamic Response = new ExpandoObject();

            try
            {
                var tournament = _context.Tournaments.FirstOrDefault(t => t.id == tournamentid && t.status == ConstantValues.EntityStatus.ACTIVE);

                if (tournament == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, tournamentid);
                    return Content(HttpStatusCode.NotFound, Response);
                }

                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.Tournament = Mapper.Map<Tournament, TournamentDto>(tournament);
                return Ok(Response);

            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }


        [HttpPost]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/tournaments")]
        public IHttpActionResult PostTournamentByLanCenter(int lancenterid,[FromBody] TournamentDto tournamentdto)
        {
            dynamic Response = new ExpandoObject();
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = ConstantValues.ErrorMessage.BAD_REQUEST;
                    return Content(HttpStatusCode.BadRequest, Response);
                }

                var tournament = Mapper.Map<TournamentDto, Tournament>(tournamentdto);
                tournament.lanCenterId = lancenterid;
                tournament.status = ConstantValues.EntityStatus.ACTIVE;
                _context.Tournaments.Add(tournament);
                _context.SaveChanges();

                tournamentdto.id = tournament.id;
                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.Tournament = tournamentdto;

                return Created(new Uri(Request.RequestUri + "/" + tournament.id), Response);
            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }


        [HttpPut]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/tournaments/{tournamentid:int}")]
        public IHttpActionResult UpdateTournamentByLanCenter(int lancenterid, int tournamentid, [FromBody] TournamentDto tournamentdto)
        {
            EntityName = "Tournament";

            dynamic Response = new ExpandoObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = ConstantValues.ErrorMessage.BAD_REQUEST;
                    return Content(HttpStatusCode.BadRequest, Response);
                }

                var tournament = _context.Tournaments.SingleOrDefault(t => t.id == tournamentid);

                if (tournament == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, tournamentid);
                    return Content(HttpStatusCode.NotFound, Response);
                }
                tournamentdto.lanCenterId = lancenterid;
                Mapper.Map(tournamentdto, tournament);
                _context.SaveChanges();

                tournamentdto.id = tournament.id;
                Response.Status = ConstantValues.ResponseStatus.OK;
                Response.Reservation = tournamentdto;
                return Ok(Response);

            }
            catch (Exception e)
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }

        [HttpDelete]
        [Route("clanbattles/v1/lancenters/{lancenterid:int}/reservations/{tournamentid:int}")]
        public IHttpActionResult DeleteTournamentByLanCenter(int lancenterid, int tournamentid)
        {
            EntityName = "Tournament";
            dynamic Response = new ExpandoObject();

            try
            {
                var tournament = _context.Tournaments.FirstOrDefault(r => r.id == tournamentid);

                if (tournament == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, tournamentid);
                    return Content(HttpStatusCode.NotFound, Response);
                }

                tournament.status = ConstantValues.EntityStatus.INACTIVE;
                _context.SaveChanges();

                Response.Status = ConstantValues.ResponseStatus.OK;

                return Ok(Response);

            }
            catch
            {
                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }
    }
}