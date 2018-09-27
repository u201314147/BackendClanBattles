using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClanBattlesService.Dtos.Info
{
	public class PublicationInfo
	{
		public int id { get; set; }
		public GamerDto gamer { get; set; }
		public GameDto game { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string urlToImage { get; set; }
		public DateTime publicationDate { get; set; }
		public string status { get; set; }
	}
}