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
        private string Id { get; set; }
        [StringLength(25)]
        private string FirstName { get; set; }
        [StringLength(25)]
        private string LastName { get; set; }
        [StringLength(20)]
        private string PhoneNumber { get; set; }
        [StringLength(50)]
        private string Description { get; set; }
        [StringLength(255)]
        private string Email { get; set; }
        [StringLength(255)]
        private string PasswordHash { get; set; }
        [StringLength(255)]
        private string Salt { get; set; }
        private int Role { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private DateTime DisabledAt { get; set; }
        private int Status { get; set; }
    }
}