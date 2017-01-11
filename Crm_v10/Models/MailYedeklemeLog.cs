namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MailYedeklemeLog")]
    public partial class MailYedeklemeLog
    {
        public int ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
         ApplyFormatInEditMode = true)]
        [Display(Name = "Tarih")]
        public DateTime? Tarih { get; set; }

        [StringLength(10)]
        [Display(Name = "Saat")]
        public string Saat { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(5)]
        [Display(Name = "Cevap")]
        public string Cevap { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
