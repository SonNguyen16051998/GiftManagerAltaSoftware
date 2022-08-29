using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Campaign
    {
        [Key]
        public int Campaign_Id { get; set; }
        [Required(ErrorMessage ="enter campaign name")]
        [Column(TypeName ="nvarchar(255)")]
        public string Campaign_Name { get; set; }
        public bool Auto_Update { get; set; }
        public bool CheckCusJoin_OnlyOnce { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public int Code_UsageLimit { get; set; }
        public bool Unlimited { get; set; }
        public int Code_Count { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Charset { get; set; }
        public int Code_Length  { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Prefix { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Postfix { get; set; }
        public int Activated_Code { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public virtual Barcode  Barcode { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; }
    }
}
