using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Winner
    {
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        [ForeignKey("Gift")]
        public int Gift_Id { get; set; }
        public DateTime Win_Date { get; set; }
        public bool Sent_Gift_Status { get; set; }
        public Customer Customer { get; set; }
        public Gift Gift { get; set; }
    }
}
