using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{

    [Table("Level")]
    public class Level
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}