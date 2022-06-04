using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("User")]
    public class User : IdentityUser
    {

        //[StringLength(10)]
        //public override string Id { get; set; }
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }
        //[StringLength(20)]
        //[Required]
        //public override string PhoneNumber { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        //[StringLength(255)]
        //[Required]
        //public override string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Salt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public int Status { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserSection> UserSections { get; set; }

    }
}