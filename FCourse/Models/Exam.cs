using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(10)]
        public string CourseId { get; set; }
        [StringLength(255)]
        public string Content { get; set; }
        public Course Course { get; set; }
    }
}