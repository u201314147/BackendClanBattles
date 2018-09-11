namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tournament")]
    public partial class Tournament
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Tournament()
        //{
        //    Participants = new HashSet<Participants>();
        //}

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int id_game { get; set; }

        public int id_lancenter { get; set; }

        //public virtual Lancenter Lancenter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Participants> Participants { get; set; }
    }
}
