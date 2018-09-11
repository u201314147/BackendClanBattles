namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members
    {
        public int id { get; set; }

        public int id_user { get; set; }

        public int id_team { get; set; }

        //public virtual Gamer Gamer { get; set; }

        //public virtual Teams Teams { get; set; }
    }
}
