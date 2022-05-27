using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [ForeignKey("Order")]
        [StringLength(10)]
        private string OrderId { get; set; }
        [ForeignKey("Course")]
        [StringLength(10)]
        private string CourseId { get; set; }
        private double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Course Course { get; set; }
    }
}