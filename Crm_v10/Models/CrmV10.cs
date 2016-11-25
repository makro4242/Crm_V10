namespace Crm_v10.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CrmV10 : DbContext
    {
        public CrmV10()
            : base("name=CrmV10")
        {
        }

        public virtual DbSet<Iller> Iller { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Potansiyel> Potansiyel { get; set; }
        public virtual DbSet<SatisElemanlari> SatisElemanlari { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ulkeler> Ulkeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Potansiyel>()
                .Property(e => e.PotansiyelNot)
                .IsUnicode(false);
        }
    }
}
