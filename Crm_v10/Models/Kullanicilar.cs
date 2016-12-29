namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            Log = new HashSet<Log>();
            Log1 = new HashSet<Log>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(5)]
        [Display(Name = "Kullanýcý Kodu")]
        public string KullaniciKodu { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanýcý Adý")]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanýcý Þifresi")]

        public string KullaniciSifresi { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Log1 { get; set; }
    }
}
