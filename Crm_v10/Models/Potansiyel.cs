namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Potansiyel")]
    public partial class Potansiyel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Potansiyel()
        {
            GorevEkleme = new HashSet<GorevEkleme>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Potansiyel Kodu")]
        public string PotansiyelKodu { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Potansiyel Unvan�")]
        public string PotansiyelUnvani { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Potansiyel Adresi")]
        public string PotansiyelAdresi { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Adres UIN Kodu")]
        public string PotansiyelAdresiUINKodu { get; set; }

        public int PotansiyelYetkiliID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "GPS Enlem")]
        public string PotansiyelAdresGpsEnlem { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "GPS Boylam")]
        public string PotansiyelAdresGpsBoylam { get; set; }

        [Display(Name = "�lke Kodu")]
        public int PotansiyelUlkeKodu { get; set; }

        [Display(Name = "�l")]
        public int PotansiyelIl { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "�l�e")]
        public string PotansiyelIlce { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Vergi Dairesi")]
        public string PotansiyelVergiDairesi { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Vergi Numaras�")]
        public string PotansiyelVergiNumarasi { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Web Adresi")]
        public string PotansiyelWebAdresi { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Sekt�r")]
        public string PotansiyelIstigalBilgisi { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Not")]
        public string PotansiyelNot { get; set; }

        [Display(Name = "Sat�� Eleman�")]
        public int PotansiyelSatisElemani { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GorevEkleme> GorevEkleme { get; set; }

        public virtual Iller Iller { get; set; }

        public virtual SatisElemanlari SatisElemanlari { get; set; }

        public virtual Ulkeler Ulkeler { get; set; }

        public virtual Yetkili Yetkili { get; set; }
    }
}
