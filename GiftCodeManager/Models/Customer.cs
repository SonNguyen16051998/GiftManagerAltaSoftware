using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GiftCodeManager.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string PhoneNo { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Position { get; set; }
        public string Type_Of_Business { get; set; }
        public string Location { get; set; }
        public bool Is_Block { get; set; }
        public ICollection<Winner> Winner { get; set; }
        public ICollection<Usedbarcode_Customer> Usedbarcode { get; set;}
    }
}
