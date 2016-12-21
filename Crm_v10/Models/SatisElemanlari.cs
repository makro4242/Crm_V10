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
            Potansiyel = new HashSet<Potansiyel>();
        }

        public int ID { get; set; }

        public int SatisElemaniKodu { get; set; }

        [Required]
        [StringLength(100)]
        public string SatisElemaniAdiSoyadi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Potansiyel> Potansiyel { get; set; }
    }
}
