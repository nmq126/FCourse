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
        private string Id { get; set; }
        [StringLength(10)]
        private string ParentId { get; set; }
        [StringLength(50)]
        private string Name { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private DateTime DisabledAt { get; set; }
        private int Status { get; set; }
    }
}