namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatisElemanlari")]
    public partial class SatisElemanlari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SatisElemanlari()
        {
            Gorev = new HashSet<Gorev>();
            Kullanicilar = new HashSet<Kullanicilar>();
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }
        [Display(Name = "Sat�� Eleman� Kodu")]

        public int SatisElemaniKodu { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Sat�� Eleman� Ad� Soyad�")]
        public string SatisElemaniAdiSoyadi { get; set; }

        [StringLength(50)]
        [Display(Name = "Sat�� Eleman� Email")]
        public string SatisElemaniEmail { get; set; }
        [StringLength(2)]
        public string GosterimDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gorev> Gorev { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kullanicilar> Kullanicilar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
