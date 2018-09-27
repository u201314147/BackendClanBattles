using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClanBattlesService.Dtos
{
    public class TournamentDto
    {
        public int id { get; set; }
        public int lanCenterId { get; set; }
        public int gameId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int numberOfParticipans { get; set; }
    }
}