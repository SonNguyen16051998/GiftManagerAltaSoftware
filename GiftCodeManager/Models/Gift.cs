using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Gift
    {
        [Key]
        public int Gift_Id  { get; set; }
        public string Gift_Name { get; set;}
        public string Description { get; set; }
        public int Code_Count { get; set; }
        public bool Active { get; set; }
        [ForeignKey("Campaign")]
        public int Campaign_Id { get; set; }
        public Campaign Campaign { get; set; }
        public Rule Rules { get; set; }
        public ICollection<Winner> Winner { get; set; }
    }
}
