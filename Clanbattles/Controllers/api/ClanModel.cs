namespace Clanbattles.Controllers.api
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClanModel : DbContext
    {
        public ClanModel()
            : base("name=ClanModel")
        {
        }

        public virtual DbSet<Comentarios> Comentarios { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Gameperlancenter> Gameperlancenter { get; set; }
        public virtual DbSet<Gamer> Gamer { get; set; }
        public virtual DbSet<Lancenter> Lancenter { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<Publication> Publication { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<Versus> Versus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Comentarios>()
            //    .Property(e => e.content)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Game>()
            //    .Property(e => e.api)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Game>()
            //    .HasMany(e => e.Gameperlancenter)
            //    .WithRequired(e => e.Game)
            //    .HasForeignKey(e => e.id_game)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Game>()
            //    .HasMany(e => e.Versus)
            //    .WithRequired(e => e.Game)
            //    .HasForeignKey(e => e.id_game)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.username)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.phone)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.pass)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.FirstName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .Property(e => e.LastName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Gamer>()
            //    .HasOptional(e => e.Comentarios)
            //    .WithRequired(e => e.Gamer);

            //modelBuilder.Entity<Gamer>()
            //    .HasMany(e => e.Members)
            //    .WithRequired(e => e.Gamer)
            //    .HasForeignKey(e => e.id_user)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Gamer>()
            //    .HasMany(e => e.Publication)
            //    .WithRequired(e => e.Gamer)
            //    .HasForeignKey(e => e.id_user)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Gamer>()
            //    .HasMany(e => e.Reservation)
            //    .WithRequired(e => e.Gamer)
            //    .HasForeignKey(e => e.id_user)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.address)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.latitude)
            //    .HasPrecision(10, 0);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.longitude)
            //    .HasPrecision(10, 0);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Lancenter>()
            //    .Property(e => e.password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Lancenter>()
            //    .HasMany(e => e.Comentarios)
            //    .WithRequired(e => e.Lancenter)
            //    .HasForeignKey(e => e.id_lancenter)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lancenter>()
            //    .HasMany(e => e.Gameperlancenter)
            //    .WithRequired(e => e.Lancenter)
            //    .HasForeignKey(e => e.id_lancenter)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lancenter>()
            //    .HasMany(e => e.Publication)
            //    .WithRequired(e => e.Lancenter)
            //    .HasForeignKey(e => e.id_lancenter)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lancenter>()
            //    .HasMany(e => e.Reservation)
            //    .WithRequired(e => e.Lancenter)
            //    .HasForeignKey(e => e.id_lancenter)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Lancenter>()
            //    .HasMany(e => e.Tournament)
            //    .WithRequired(e => e.Lancenter)
            //    .HasForeignKey(e => e.id_lancenter)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Publication>()
            //    .Property(e => e.content)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Reservation>()
            //    .Property(e => e.message)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Teams>()
            //    .Property(e => e.name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Teams>()
            //    .Property(e => e.logo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Teams>()
            //    .HasMany(e => e.Members)
            //    .WithRequired(e => e.Teams)
            //    .HasForeignKey(e => e.id_team)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Teams>()
            //    .HasMany(e => e.Participants)
            //    .WithRequired(e => e.Teams)
            //    .HasForeignKey(e => e.id_team)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Teams>()
            //    .HasMany(e => e.Versus)
            //    .WithRequired(e => e.Teams)
            //    .HasForeignKey(e => e.id_team2)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Teams>()
            //    .HasMany(e => e.Versus1)
            //    .WithRequired(e => e.Teams1)
            //    .HasForeignKey(e => e.id_team2)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Tournament>()
            //    .HasMany(e => e.Participants)
            //    .WithRequired(e => e.Tournament)
            //    .HasForeignKey(e => e.id_tournament)
            //    .WillCascadeOnDelete(false);
        }
    }
}
