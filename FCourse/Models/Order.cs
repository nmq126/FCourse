using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DisabledAt { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
    }
}