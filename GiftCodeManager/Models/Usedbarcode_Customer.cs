using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Usedbarcode_Customer
    {
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        [ForeignKey("Barcode")]
        public int Barcode_Id { get; set; }
        public DateTime Spin_Date { get; set; }
        public DateTime Scanned_Date { get; set; }
        public bool Scanned_Status { get; set; }
        public bool Used_for_pin { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Barcode Barcode { get; set; }

    }
}
