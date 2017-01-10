namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int ID { get; set; }

        public int KayitID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tablo Adý")]

        public string TabloAdi { get; set; }

        [Display(Name = "Oluþturan Kullanýcý")]

        public int OlusturanKullanici { get; set; }

        [Display(Name = "Oluþturulan Tarih")]

        public DateTime? OlusturulanTarih { get; set; }

        [Display(Name = "Deðiþtiren Kullanýcý")]

        public int DegistirenKullanici { get; set; }

        [Display(Name = "Deðiþtirilen Tarih")]
        public DateTime? DegistirilenTarih { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Kullanicilar Kullanicilar1 { get; set; }
    }
}
