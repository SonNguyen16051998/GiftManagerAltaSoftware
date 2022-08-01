using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftCodeManager.Models
{
    public class Campaign
    {
        [Key]
        public int Campaign_Id { get; set; }
        public string Campaign_Name { get; set; }
        public bool Auto_Update { get; set; }
        public bool CheckCusJoin_OnlyOnce { get; set; }
        public string Description { get; set; }
        public int Code_UsageLimit { get; set; }
        public bool Unlimited { get; set; }
        public int Code_Count { get; set; }
        public string Charset { get; set; }
        public int Code_Length  { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public Barcode  Barcode { get; set; }
        public ICollection<Gift> Gifts { get; set; }
    }
}
