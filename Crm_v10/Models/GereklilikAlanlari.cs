namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GereklilikAlanlari")]
    public partial class GereklilikAlanlari
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string GerekliAlanAdlari { get; set; }

        [StringLength(50)]
        public string SayfaAdi { get; set; }

        [StringLength(2)]
        public string GereklilikDurumu { get; set; }
    }
}
