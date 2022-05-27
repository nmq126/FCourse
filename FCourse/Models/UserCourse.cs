using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("UserCourse")]
    public class UserCourse
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CourseId { get; set; }
        public string Grade { get; set; }
        public bool IsFinished { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }

    }
}