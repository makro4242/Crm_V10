namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AksiyonSecim")]
    public partial class AksiyonSecim
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Aksiyon Adý")]

        public string AksiyonAdi { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }
    }
}
