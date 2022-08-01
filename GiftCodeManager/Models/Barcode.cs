using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Barcode
    {
        [Key,ForeignKey("Campaign")]
        public int Campaign_Id { get; set; }
        public string Code { get; set;}
        public int Code_redemption_limit { get; set; }
        public DateTime Created_Date { get; set; }
        public bool Unlimited { get; set; }
        public int Code_count { get; set; }
        public string Charset { get; set; }
        public int Code_Length { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public Campaign Campaign { get; set; }
        public ICollection<Usedbarcode_Customer> usedbarcode_Customers { get; set; }
    }
}
