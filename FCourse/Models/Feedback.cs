using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CourseId { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string UserId { get; set; }
        public int Rating { get; set; }
        [StringLength(255)]
        public string Content { get; set; }
    }
}