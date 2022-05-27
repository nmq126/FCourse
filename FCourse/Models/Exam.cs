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
        private string Id { get; set; }
        [StringLength(50)]
        private string Name { get; set; }
        [StringLength(10)]
        private string CourseId { get; set; }
        [StringLength(255)]
        private string Content { get; set; }
        private Course Course { get; set; }
    }
}