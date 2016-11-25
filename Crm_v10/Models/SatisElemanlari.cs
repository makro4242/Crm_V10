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
        public int ID { get; set; }

        public int SatisElemaniKodu { get; set; }

        [Required]
        [StringLength(100)]
        public string SatisElemaniAdiSoyadi { get; set; }
    }
}
