namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GorevEkleme")]
    public partial class GorevEkleme
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime? Tarih { get; set; }

        public int? PotansiyelID { get; set; }

        public int? SatisElemaniID { get; set; }

        [Column(TypeName = "money")]
        public decimal? TahminiTutar { get; set; }

        [StringLength(250)]
        public string GorevNot { get; set; }

        [StringLength(50)]
        public string Durum { get; set; }

        [StringLength(50)]
        public string Oncelik { get; set; }

        public virtual Potansiyel Potansiyel { get; set; }

        public virtual SatisElemanlari SatisElemanlari { get; set; }
    }
}
