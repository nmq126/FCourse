using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("QnA")]
    public class QnA
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [ForeignKey("Course")]
        [StringLength(10)]
        public string CourseId { get; set; }
        [StringLength(255)]
        public string Question { get; set; }
        [StringLength(255)]
        public string Answer { get; set; }
        public virtual Course Course { get; set; }
    }
}