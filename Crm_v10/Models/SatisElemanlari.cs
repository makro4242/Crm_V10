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
            GorevEkleme = new HashSet<Gorev>();
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        [Display(Name = "Satýþ Elemaný Kodu")]
        public int SatisElemaniKodu { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Satýþ Elemaný Adý Soyadý")]
        public string SatisElemaniAdiSoyadi { get; set; }
        [StringLength(2)]
        public string GosterimDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gorev> GorevEkleme { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
