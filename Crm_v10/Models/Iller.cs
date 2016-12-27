namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iller")]
    public partial class Iller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Iller()
        {
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        [Display(Name = "�l Kodu")]
        public int IlKodu { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "�l Ad�")]
        public string IlAdi { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Telefon Alan Kodu")]
        public string IlTelefonAlanKodu { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Plaka Kodu")]
        public string IlPlakaKodu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
