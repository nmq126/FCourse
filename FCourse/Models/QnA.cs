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
        private string Id { get; set; }
        [StringLength(10)]
        private string CourseId { get; set; }
        [StringLength(255)]
        private string Question { get; set; }
        [StringLength(255)]
        private string Answer { get; set; }
        private Course Course { get; set; }
    }
}