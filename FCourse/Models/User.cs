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
    public class User
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }
        [StringLength(20)]
        [Required]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [StringLength(255)]
        [Required]
        public string Email { get; set; }
        [StringLength(255)]
        public string PasswordHash { get; set; }
        [StringLength(255)]
        public string Salt { get; set; }
        public int Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public int Status { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}