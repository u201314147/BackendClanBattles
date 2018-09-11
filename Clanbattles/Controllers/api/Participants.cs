namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participants
    {
        public int id { get; set; }

        public int id_team { get; set; }

        public int id_tournament { get; set; }

        //public virtual Teams Teams { get; set; }

        //public virtual Tournament Tournament { get; set; }
    }
}
