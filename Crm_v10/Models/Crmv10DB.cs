namespace Crm_v10.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Crmv10DB : DbContext
    {
        public Crmv10DB()
            : base("name=Crmv10DB")
        {
        }

        public virtual DbSet<Iller> Iller { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Potansiyel> Potansiyel { get; set; }
        public virtual DbSet<SatisElemanlari> SatisElemanlari { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ulkeler> Ulkeler { get; set; }
        public virtual DbSet<Yetkili> Yetkili { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Iller>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Iller)
                .HasForeignKey(e => e.PotansiyelIl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Potansiyel>()
                .Property(e => e.PotansiyelNot)
                .IsUnicode(false);

            modelBuilder.Entity<SatisElemanlari>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.SatisElemanlari)
                .HasForeignKey(e => e.PotansiyelSatisElemani)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulkeler>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Ulkeler)
                .HasForeignKey(e => e.PotansiyelUlkeKodu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yetkili>()
                .HasMany(e => e.Potansiyel)
                .WithOptional(e => e.Yetkili)
                .HasForeignKey(e => e.PotansiyelYetkiliID);
        }
    }
}
