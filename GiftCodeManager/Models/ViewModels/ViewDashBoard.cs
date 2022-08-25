using System;
using System.ComponentModel.DataAnnotations;

namespace GiftCodeManager.Models.ViewModels
{
    public class ViewDashBoard
    {
        [Key]
        public string Name_Campaign { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_Date { get; set; }
        public int Activated_Code { get; set; }
        public int Qty_Gift { get; set; }
        public int Scanned { get; set; }
        public int Winners { get; set; }
    }
}
