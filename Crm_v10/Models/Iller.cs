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
        public int ID { get; set; }

        public int IlKodu { get; set; }

        [Required]
        [StringLength(100)]
        public string IlAdi { get; set; }

        [Required]
        [StringLength(4)]
        public string IlTelefonAlanKodu { get; set; }

        [Required]
        [StringLength(3)]
        public string IlPlakaKodu { get; set; }
    }
}
