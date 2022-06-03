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
        [Key]
        [Column(Order = 0)]
        public string OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CourseId { get; set; }

        public double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Course Course { get; set; }
    }
}