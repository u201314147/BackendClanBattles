using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClanBattlesService.Dtos
{
	public class PublicationDto
	{

		public int id { get; set; }
		public int gamerId { get; set; }
		public int gameId { get; set; }
		public string title { get; set; }
		public string description { get; set; }
		public string urlToImage { get; set; }
		public DateTime publicationDate { get; set; }
		public string status { get; set; }

	}
}