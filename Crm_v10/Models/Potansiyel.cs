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
            Gorev = new HashSet<Gorev>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Potansiyel Kodu")]

        public string PotansiyelKodu { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Potansiyel Ünvaný")]
        public string PotansiyelUnvani { get; set; }

        [StringLength(150)]
        [Display(Name = "Potansiyel Adresi")]
        public string PotansiyelAdresi { get; set; }

        [StringLength(20)]
        [Display(Name = "Adres UIN Kodu")]
        public string PotansiyelAdresiUINKodu { get; set; }

        public int PotansiyelYetkiliID { get; set; }

        [StringLength(20)]
        [Display(Name = "GPS Enlem")]
        public string PotansiyelAdresGpsEnlem { get; set; }

        [StringLength(20)]
        [Display(Name = "GPS Boylam")]
        public string PotansiyelAdresGpsBoylam { get; set; }

        [Display(Name = "Ülke Kodu")]
        public int PotansiyelUlkeKodu { get; set; }

        [Display(Name = "Ýl")]
        public int PotansiyelIl { get; set; }

        [StringLength(50)]
        [Display(Name = "Ýlce")]

        public string PotansiyelIlce { get; set; }

        [StringLength(50)]
        [Display(Name = "Vergi Dairesi")]
        public string PotansiyelVergiDairesi { get; set; }

        [StringLength(50)]
        [Display(Name = "Vergi Numarasý")]
        public string PotansiyelVergiNumarasi { get; set; }

        [StringLength(50)]
        [Display(Name = "Potansiyel Email")]
        public string PotansiyelEmail { get; set; }

        [StringLength(80)]
        [Display(Name = "Web Adresi")]
        public string PotansiyelWebAdresi { get; set; }

        public int PotansiyelSektorID { get; set; }

        [Column(TypeName = "text")]
        public string PotansiyelNot { get; set; }

        [Display(Name = "Satýþ Elemaný")]
        public int PotansiyelSatisElemani { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gorev> Gorev { get; set; }

        public virtual Iller Iller { get; set; }

        public virtual SatisElemanlari SatisElemanlari { get; set; }

        public virtual Sektor Sektor { get; set; }

        public virtual Ulkeler Ulkeler { get; set; }

        public virtual Yetkili Yetkili { get; set; }
    }
}
