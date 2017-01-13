namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ulkeler")]
    public partial class Ulkeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ulkeler()
        {
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        [Display(Name = "Ülke Kodu")]
        public int? UlkeKodu { get; set; }

        [StringLength(5)]
        [Display(Name = "Ülke Kýsa Adý")]
        public string UlkeKisaAdi { get; set; }

        [StringLength(50)]
        [Display(Name = "Ülke Adý")]
        public string UlkeAdi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
