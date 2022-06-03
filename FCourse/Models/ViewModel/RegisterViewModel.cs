using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models.ViewModel
{
    public class RegisterViewModel
    {

        [StringLength(25)]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}