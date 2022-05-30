using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
        [StringLength(10)]
        [Required]
        public string CategoryId { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public string Detail { get; set; }
        public double Duration { get; set; }
        [StringLength(10)]
        [Required]
        public string LevelId { get; set; }
        public double Rating { get; set; }
        [StringLength(255)]
        [Required]
        public string Thumbnail { get; set; }
        [Required]
        public double Price { get; set; }
        public int Discount { get; set; }
        [StringLength(10)]
        [Required]
        public string TeacherId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual Level Level { get; set; }
        public ICollection<Section> Sections { get; set; }
    }
}