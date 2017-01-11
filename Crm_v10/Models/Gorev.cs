namespace Crm_v10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gorev")]
    public partial class Gorev
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gorev()
        {
            Aksiyon = new HashSet<Aksiyon>();
        }

        public int ID { get; set; }

        [StringLength(500)]
        [Display(Name = "Açýklama")]

        public string Aciklama { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
           ApplyFormatInEditMode = true)]
        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

        public int PotansiyelID { get; set; }

        public int SatisElemaniID { get; set; }

        [StringLength(10)]
        [Display(Name = "Para Birimi")]

        public string ParaBirimi { get; set; }

        [Display(Name = "Tahmini Tutar")]
        public decimal TahminiTutar { get; set; }

        [Required]
        [Display(Name = "Görev Not")]

        public string GorevNot { get; set; }

        public int DurumID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Öncelik")]

        public string Oncelik { get; set; }

        [StringLength(2)]
        public string GosterimDurumu { get; set; }
        public string BirlesikGorev
        {
            get
            {
                return String.Format("{0} {1} {2}", ID, SatisElemanlari.SatisElemaniAdiSoyadi, Potansiyel.PotansiyelKodu);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aksiyon> Aksiyon { get; set; }

        public virtual Durum Durum { get; set; }

        public virtual Potansiyel Potansiyel { get; set; }

        public virtual SatisElemanlari SatisElemanlari { get; set; }
    }
}
