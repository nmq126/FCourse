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
        private string CourseId { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        private string UserId { get; set; }
        private int Rating { get; set; }
        [StringLength(255)]
        private string Content { get; set; }
    }
}