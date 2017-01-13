namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("YetkilendirmeAyar")]
    public partial class YetkilendirmeAyar
    {
        public int ID { get; set; }

        [Display(Name = "Kullan�c� ID")]
        public int? KullaniciID { get; set; }

        [StringLength(50)]
        [Display(Name = "Kullan�c� Ad�")]
        public string SayfaAdi { get; set; }

        [StringLength(2)]
        [Display(Name = "Yetki Durumu")]
        public string YetkiDurumu { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
