namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Versus
    {
        public int id { get; set; }

        public int id_team1 { get; set; }

        public int id_team2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int id_game { get; set; }

        //public virtual Game Game { get; set; }

        //public virtual Teams Teams { get; set; }

        //public virtual Teams Teams1 { get; set; }
    }
}
