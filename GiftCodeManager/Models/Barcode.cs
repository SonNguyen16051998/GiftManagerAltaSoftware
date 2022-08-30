using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Barcode
    {
        [Key]
        public int BarcodeId { get; set;}
        
        [Required]
        public int Code_redemption_limit { get; set; }
        public DateTime Created_Date { get; set; }
        public bool Unlimited { get; set; }
        [Required]
        public int Code_count { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Charset { get; set; }
        public int Scanned { get; set; }
        [Required]
        public int Code_Length { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Prefix { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Postfix { get; set; }
        [ForeignKey("Campaign")]
        public int Campaign_Id { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<Usedbarcode_Customer> usedbarcode_Customers { get; set; }
    }
}
