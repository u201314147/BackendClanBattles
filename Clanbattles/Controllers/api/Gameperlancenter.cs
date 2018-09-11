namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gameperlancenter")]
    public partial class Gameperlancenter
    {
        public int id { get; set; }

        public int id_lancenter { get; set; }

        public int id_game { get; set; }

        //public virtual Game Game { get; set; }

        //public virtual Lancenter Lancenter { get; set; }
    }
}
