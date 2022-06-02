using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCourse.Models
{
    public class CartItem
    {
        public Course course { get; set; }
    }

    public class Cart
    {
        [Key]
        public string Id { get; set; }

        private List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public bool Add(Course courseAdd)
        {
            var item = items.FirstOrDefault(s => s.course.Id == courseAdd.Id);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    course = courseAdd
                });
                return true;
            }
            else
            {
                return false;
            }
        }

        public double Total()
        {
            var total = items.Sum(s => s.course.Price * (1 - s.course.Discount / 100));
            return total;
        }

        public double OriginalTotal()
        {
            var originalTotal = items.Sum(s => s.course.Price);
            return originalTotal;
        }

        public double DiscountPrice()
        {
            var discountPrice = items.Sum(s => s.course.Price * s.course.Discount / 100);
            return discountPrice;
        }

        public void RemoveCartItem(string id)
        {
            items.RemoveAll(s => s.course.Id == id);
        }
    }
}