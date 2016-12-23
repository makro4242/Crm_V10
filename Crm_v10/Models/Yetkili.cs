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
        public string YetkiliKodu { get; set; }

        [Required]
        [StringLength(50)]
        public string YetkiliAd { get; set; }

        [Required]
        [StringLength(50)]
        public string YetkiliSoyad { get; set; }

        [Required]
        [StringLength(11)]
        public string YetkiliGSM1 { get; set; }

        [StringLength(11)]
        public string YetkiliGSM2 { get; set; }

        [Required]
        [StringLength(50)]
        public string YetkiliMail1 { get; set; }

        [StringLength(50)]
        public string YetkiliMail2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
             ApplyFormatInEditMode = true)]
        public DateTime? YetkiliDogumTarihi { get; set; }


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
