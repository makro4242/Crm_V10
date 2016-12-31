namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yetkili")]
    public partial class Yetkili
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yetkili()
        {
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Yetkili Kodu")]
        public string YetkiliKodu { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Yetkili Ad")]
        public string YetkiliAd { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Yetkili Soyad")]

        public string YetkiliSoyad { get; set; }

        [StringLength(15)]
        [Display(Name = "GSM1")]

        public string YetkiliGSM1 { get; set; }

        [StringLength(15)]
        [Display(Name = "GSM2")]
        public string YetkiliGSM2 { get; set; }

        [StringLength(50)]
        [Display(Name = "Email1")]

        public string YetkiliMail1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Email2")]

        public string YetkiliMail2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        [Display(Name = "Yetkili Doðum Tarihi")]
        public DateTime? YetkiliDogumTarihi { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", YetkiliAd, YetkiliSoyad);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
