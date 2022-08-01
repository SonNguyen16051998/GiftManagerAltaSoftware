using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiftCodeManager.Models
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 1,
        [Display(Name = "Female")]
        Female = 2
    }
    public enum Role
    {
        [Display(Name = "Admin")]
        Admin = 1,
        [Display(Name = "Staff")]
        Staff = 2
    }
    public enum Status
    {
        [Display(Name = "Lock")]
        Lock = 1,
        [Display(Name = "Active")]
        Active = 2
    }
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        [Required(ErrorMessage = "Enter user email"), DataType(DataType.EmailAddress)]
        [StringLength(30)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter user name")]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "Enter user address.")]
        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "Char(15)"), Display(Name = "Phone number")]
        [Required(ErrorMessage = "Enter user phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Choose gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Choose birthday")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Choose role")]
        public Role Role { get; set; }
        [Required, Range(1, int.MaxValue, ErrorMessage = "Choose active status")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "Enter user password")]
        [Column(TypeName = "varchar(50)"), MinLength(6, ErrorMessage = "Password to 6-12 characters")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Enter retype password")]
        [Column(TypeName = "varchar(50)"), MinLength(6, ErrorMessage = "Password to 6-12 characters")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Password does not match!!!")]
        [NotMapped]
        public string RetypePassWord { get; set; }
    }
}
