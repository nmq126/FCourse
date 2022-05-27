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
        [StringLength(10)]
        private string UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        private string SectionId { get; set; }
        private string PausedAt { get; set; }
        private string IsFinished { get; set; }
    }
}