using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        [Key]
        [StringLength(10)]
        public String Id { get; set; }
        [StringLength(50)]
        public String Name { get; set; }
        [Column(TypeName = "ntext")]
        public String Thumbnail { get; set; }
        [Column(TypeName = "ntext")]
        public String Description { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}