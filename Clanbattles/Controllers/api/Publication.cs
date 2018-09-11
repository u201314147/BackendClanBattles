namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publication")]
    public partial class Publication
    {
        public int id { get; set; }

        public int id_lancenter { get; set; }

        [Required]
        [StringLength(300)]
        public string content { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int id_user { get; set; }

        //public virtual Gamer Gamer { get; set; }

        //public virtual Lancenter Lancenter { get; set; }
    }
}
