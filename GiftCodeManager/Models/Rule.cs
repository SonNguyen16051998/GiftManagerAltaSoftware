using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Rule
    {
        [Key,ForeignKey("Gift")]
        public int Gift_Id { get; set; }
        [Required(ErrorMessage ="enter rule name")]
        [Column(TypeName = "nvarchar(255)")]
        public string Rule_Name { get; set;}
        public double Gift_Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool AllDay { get; set; }
        public int Probability { get; set; }
        public DateTime Monthly_On_Day { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime_Repeat { get; set; }
        public TimeSpan EndTime_Repeat { get; set; }
        public virtual Gift Gift { get; set; }
    }
}
