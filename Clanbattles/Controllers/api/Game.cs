namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Game()
        //{
        //    Gameperlancenter = new HashSet<Gameperlancenter>();
        //    Versus = new HashSet<Versus>();
        //}

        public int id { get; set; }

        public int name { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string api { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Gameperlancenter> Gameperlancenter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Versus> Versus { get; set; }
    }
}
