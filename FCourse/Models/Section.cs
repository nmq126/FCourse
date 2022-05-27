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
        private string Id { get; set; }
        [ForeignKey("Course")]
        [StringLength(10)]
        private string CourseId { get; set; }
        [StringLength(10)]
        private string Name { get; set; }
        private int Type { get; set; }
        [Column(TypeName = "ntext")]
        private string Content { get; set; }
        private double Duration { get; set; }
        private int Order { get; set; }
        public virtual Course Course { get; set; }
    }
}