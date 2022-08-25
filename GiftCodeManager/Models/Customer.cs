using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        [Required(ErrorMessage ="enter your email")]
        [Column(TypeName ="varchar(30)")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set;}
        [Column(TypeName =("nvarchar(50)"))]
        [Required(ErrorMessage ="enter your name")]
        public string Customer_Name { get; set; }

        [Column(TypeName = ("varchar(15)"))]
        [Required(ErrorMessage ="enter your phone numer")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        [Column(TypeName = ("nvarchar(255)"))]
        public string Position { get; set; }
        [Column(TypeName = ("nvarchar(255)"))]
        public string Type_Of_Business { get; set; }
        [Column(TypeName = ("nvarchar(255)"))]
        [Required]
        public string Location { get; set; }
        public int Spin_Number { get; set; }
        [Column(TypeName =("varchar(255)")),MinLength(6,ErrorMessage ="password to 6-15 character")]
        [Required(ErrorMessage ="enter password"),DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Column(TypeName = ("varchar(255)")), MinLength(6, ErrorMessage = "password to 6-15 character")]
        [Required(ErrorMessage = "enter compare password")]
        [Compare("Password",ErrorMessage ="retype pass not match")]
        [DataType(DataType.Password)]
        public string RetypePassword { get; set; }
        public ICollection<Winner> Winner { get; set; }
        public ICollection<Usedbarcode_Customer> Usedbarcode { get; set;}
    }
}
