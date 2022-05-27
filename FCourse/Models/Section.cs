using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Section")]
    public class Section
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [Required]
        [StringLength(10)]
        public string CourseId { get; set; }
        [StringLength(10)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Type { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }
        public double Duration { get; set; }
        [Required]
        public int Order { get; set; }
        public virtual Course Course { get; set; }
    }
}