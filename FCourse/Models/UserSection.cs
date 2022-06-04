using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("UserSection")]
    public class UserSection
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string SectionId { get; set; }
        public double PausedAt { get; set; }
        public bool IsFinished { get; set; }
        public virtual User User { get; set; }
        public virtual Section Section { get; set; }
    }
}