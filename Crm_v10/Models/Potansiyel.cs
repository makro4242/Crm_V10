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
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string PotansiyelKodu { get; set; }

        [Required]
        [StringLength(150)]
        public string PotansiyelUnvani { get; set; }

        [Required]
        [StringLength(150)]
        public string PotansiyelAdresi { get; set; }

        [Required]
        [StringLength(20)]
        public string PotansiyelAdresiUINKodu { get; set; }

        public int PotansiyelYetkiliID { get; set; }

        [Required]
        [StringLength(20)]
        public string PotansiyelAdresGpsEnlem { get; set; }

        [Required]
        [StringLength(20)]
        public string PotansiyelAdresGpsBoylam { get; set; }

        public int PotansiyelUlkeKodu { get; set; }

        public int PotansiyelIl { get; set; }

        [Required]
        [StringLength(50)]
        public string PotansiyelIlce { get; set; }

        [Required]
        [StringLength(50)]
        public string PotansiyelVergiDairesi { get; set; }

        [Required]
        [StringLength(50)]
        public string PotansiyelVergiNumarasi { get; set; }

        [Required]
        [StringLength(80)]
        public string PotansiyelWebAdresi { get; set; }

        [Required]
        [StringLength(100)]
        public string PotansiyelIstigalBilgisi { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PotansiyelNot { get; set; }

        public int PotansiyelSatisElemani { get; set; }
    }
}
