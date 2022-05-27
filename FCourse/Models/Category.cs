using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(10)]
        public string ParentId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public int Status { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}