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
        public string PotansiyelKodu { get; set; }

        [Required]
        [StringLength(150)]
        public string PotansiyelUnvani { get; set; }

        [StringLength(150)]
        public string PotansiyelAdresi { get; set; }

        [StringLength(20)]
        public string PotansiyelAdresiUINKodu { get; set; }

        public int PotansiyelYetkiliID { get; set; }

        [StringLength(20)]
        public string PotansiyelAdresGpsEnlem { get; set; }

        [StringLength(20)]
        public string PotansiyelAdresGpsBoylam { get; set; }

        public int PotansiyelUlkeKodu { get; set; }

        public int PotansiyelIl { get; set; }

        [StringLength(50)]
        public string PotansiyelIlce { get; set; }

        [StringLength(50)]
        public string PotansiyelVergiDairesi { get; set; }

        [StringLength(50)]
        public string PotansiyelVergiNumarasi { get; set; }

        [StringLength(50)]
        public string PotansiyelEmail { get; set; }

        [StringLength(80)]
        public string PotansiyelWebAdresi { get; set; }

        public int PotansiyelSektorID { get; set; }

        [Column(TypeName = "text")]
        public string PotansiyelNot { get; set; }

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
