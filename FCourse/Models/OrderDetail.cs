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
        [StringLength(10)]
        private string OrderId { get; set; }
        [StringLength(10)]
        private string CourseId { get; set; }
        private double UnitPrice { get; set; }
        private Order Order { get; set; }
        private Course Course { get; set; }
    }
}