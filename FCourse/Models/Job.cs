using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Job")]
    public class Job
    {
        [Key]
        [StringLength(10)]
        private string Id { get; set; }
        [StringLength(50)]
        private string Name { get; set; }
        [StringLength(255)]
        private string Description { get; set; }
        [StringLength(255)]
        private string Thumbnail { get; set; }
    }
}