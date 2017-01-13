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

        public virtual DbSet<Aksiyon> Aksiyon { get; set; }
        public virtual DbSet<AksiyonSecim> AksiyonSecim { get; set; }
        public virtual DbSet<Durum> Durum { get; set; }
        public virtual DbSet<GereklilikAlanlari> GereklilikAlanlari { get; set; }
        public virtual DbSet<Gorev> Gorev { get; set; }
        public virtual DbSet<Iller> Iller { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<MailYedeklemeLog> MailYedeklemeLog { get; set; }
        public virtual DbSet<Potansiyel> Potansiyel { get; set; }
        public virtual DbSet<SatisElemanlari> SatisElemanlari { get; set; }
        public virtual DbSet<Sektor> Sektor { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ulkeler> Ulkeler { get; set; }
        public virtual DbSet<YetkilendirmeAyar> YetkilendirmeAyar { get; set; }
        public virtual DbSet<Yetkili> Yetkili { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Durum>()
                .HasMany(e => e.Gorev)
                .WithRequired(e => e.Durum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gorev>()
                .Property(e => e.TahminiTutar)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Gorev>()
                .HasMany(e => e.Aksiyon)
                .WithRequired(e => e.Gorev)
                .HasForeignKey(e => e.GorevEklemeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Iller>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Iller)
                .HasForeignKey(e => e.PotansiyelIl)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.Log)
                .WithRequired(e => e.Kullanicilar)
                .HasForeignKey(e => e.OlusturanKullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.Log1)
                .WithRequired(e => e.Kullanicilar1)
                .HasForeignKey(e => e.DegistirenKullanici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.MailYedeklemeLog)
                .WithOptional(e => e.Kullanicilar)
                .HasForeignKey(e => e.KullaniciID);

            modelBuilder.Entity<Kullanicilar>()
                .HasMany(e => e.YetkilendirmeAyar)
                .WithOptional(e => e.Kullanicilar)
                .HasForeignKey(e => e.KullaniciID);

            modelBuilder.Entity<Potansiyel>()
                .Property(e => e.PotansiyelNot)
                .IsUnicode(false);

            modelBuilder.Entity<Potansiyel>()
                .HasMany(e => e.Gorev)
                .WithRequired(e => e.Potansiyel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisElemanlari>()
                .HasMany(e => e.Gorev)
                .WithRequired(e => e.SatisElemanlari)
                .HasForeignKey(e => e.SatisElemaniID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisElemanlari>()
                .HasMany(e => e.Kullanicilar)
                .WithOptional(e => e.SatisElemanlari)
                .HasForeignKey(e => e.SatisElemaniID);

            modelBuilder.Entity<SatisElemanlari>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.SatisElemanlari)
                .HasForeignKey(e => e.PotansiyelSatisElemani)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sektor>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Sektor)
                .HasForeignKey(e => e.PotansiyelSektorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulkeler>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Ulkeler)
                .HasForeignKey(e => e.PotansiyelUlkeKodu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Yetkili>()
                .HasMany(e => e.Potansiyel)
                .WithRequired(e => e.Yetkili)
                .HasForeignKey(e => e.PotansiyelYetkiliID)
                .WillCascadeOnDelete(false);
        }
    }
}
