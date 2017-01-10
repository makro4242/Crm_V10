namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sektor")]
    public partial class Sektor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sektor()
        {
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        [StringLength(150)]
        [Display(Name = "Sektör")]

        public string SektorAd { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
