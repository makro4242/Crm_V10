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

 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(10)]
        public string Saat { get; set; }
        
        public int GorevEklemeID { get; set; }

       
        [Required]
        [StringLength(50)]
        public string AksiyonSecim { get; set; }

        [Required]
        public string AksiyonNot { get; set; }

        public string Ekler1 { get; set; }
        public string Ekler2 { get; set; }
        public string Ekler3 { get; set; }
        public string Ekler4 { get; set; }
        public string Ekler5 { get; set; }





        public virtual GorevEkleme GorevEkleme { get; set; }
    }
}
