namespace Clanbattles.Controllers.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lancenter")]
    public partial class Lancenter
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Lancenter()
        //{
        //    Comentarios = new HashSet<Comentarios>();
        //    Gameperlancenter = new HashSet<Gameperlancenter>();
        //    Publication = new HashSet<Publication>();
        //    Reservation = new HashSet<Reservation>();
        //    Tournament = new HashSet<Tournament>();
        //}

        public int id { get; set; }

        [Required]
        [StringLength(75)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        public decimal latitude { get; set; }

        public decimal longitude { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Comentarios> Comentarios { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Gameperlancenter> Gameperlancenter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Publication> Publication { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Reservation> Reservation { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Tournament> Tournament { get; set; }
    }
}
