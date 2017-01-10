namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aksiyon")]
    public partial class Aksiyon
    {
        public int ID { get; set; }

        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(10)]
        public string Saat { get; set; }

        public int GorevEklemeID { get; set; }

        public int AksiyonSecimID { get; set; }

        [Required]
        public string AksiyonNot { get; set; }

        public string Ekler1 { get; set; }

        public string Ekler2 { get; set; }

        public string Ekler3 { get; set; }

        public string Ekler4 { get; set; }

        public string Ekler5 { get; set; }

        public virtual AksiyonSecim AksiyonSecim { get; set; }

        public virtual Gorev Gorev { get; set; }
    }
}
