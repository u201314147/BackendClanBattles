using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClanBattlesService.Models;
using ClanBattlesService.Dtos;
using System.Dynamic;
using System.Text;
using AutoMapper;

namespace ClanBattlesService.Controllers.ClanBattlesApi
{
    public class GamerAccountsController : ApiController
    {
        private ClanBattlesEntities _context;
        private string EntityName = "Gamer";

        GamerAccountsController()
        {
            _context = new ClanBattlesEntities();
        }

        
        [HttpPost]
        [Route("clanbattles/v1/accounts")]
        public IHttpActionResult Authenticate(AccountDto accountDto)
        {
            dynamic Response = new ExpandoObject();

            try
            {
                var gamer = _context.Gamers.SingleOrDefault(g =>
                    g.username.Equals(accountDto.username) && g.password.Equals(accountDto.password));

                if (gamer == null)
                {
                    Response.Status = ConstantValues.ResponseStatus.ERROR;
                    Response.Message = string.Format(ConstantValues.ErrorMessage.NOT_FOUND, EntityName, "#");
                    return Content(HttpStatusCode.NotFound, Response);
                }

                Response.Status = ConstantValues.ResponseStatus.OK;
                String uncoded = gamer.username + ":" + gamer.password;
                Response.Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(uncoded));
                Response.Gamer = Mapper.Map<Gamer, GamerDto>(gamer);
                return Content(HttpStatusCode.OK, Response);
            }
            catch (Exception e)
            {

                Response.Status = ConstantValues.ResponseStatus.ERROR;
                Response.Message = ConstantValues.ErrorMessage.INTERNAL_SERVER_ERROR;
                return Content(HttpStatusCode.InternalServerError, Response);
            }
        }
    }
}
