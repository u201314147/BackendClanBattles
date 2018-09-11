namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int id { get; set; }

        public int id_lancenter { get; set; }

        [Required]
        [StringLength(300)]
        public string message { get; set; }

        public int state { get; set; }

        public int id_user { get; set; }

        //public virtual Gamer Gamer { get; set; }

        //public virtual Lancenter Lancenter { get; set; }
    }
}
