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
        private string Id { get; set; }
        [ForeignKey("Category")]
        [StringLength(10)]
        private string CategoryId { get; set; }
        [ForeignKey("Job")]
        [StringLength(10)]
        private string JobId { get; set; }
        [StringLength(255)]
        private string Name { get; set; }
        [StringLength(255)]
        private string Description { get; set; }
        [StringLength(255)]
        private string Detail { get; set; }
        private double Duration { get; set; }
        [StringLength(10)]
        [ForeignKey("Level")]
        private string LevelId { get; set; }
        private double Rating { get; set; }
        [StringLength(255)]
        private string Thumbnail { get; set; }
        private double Price { get; set; }
        private int Discount { get; set; }
        [StringLength(10)]
        private string TeacherId { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
        private DateTime DisabledAt { get; set; }
        private int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual Level Level { get; set; }
        public virtual Job Job { get; set; }
    }
}