namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comentarios
    {
        public int id { get; set; }

        public int id_lancenter { get; set; }

        public int id_user { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string content { get; set; }

        //public virtual Gamer Gamer { get; set; }

        //public virtual Lancenter Lancenter { get; set; }
    }
}
