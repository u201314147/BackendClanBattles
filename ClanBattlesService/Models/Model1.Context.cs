﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClanBattlesService.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClanBattlesEntities : DbContext
    {
        public ClanBattlesEntities()
            : base("name=ClanBattlesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<Gamer> Gamers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Games_LanCenters> Games_LanCenters { get; set; }
        public virtual DbSet<LanCenter> LanCenters { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
    }
}