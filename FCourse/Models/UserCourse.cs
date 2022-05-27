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
        private string IdUser { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        private string IdCourse { get; set; }
        private string Grade { get; set; }
        private string IsFinished { get; set; }
    }
}