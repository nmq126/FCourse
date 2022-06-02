using FCourse.Data;
using FCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FCourse.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBContext db = new DBContext();

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        [HttpPost]
        public JsonResult AddtoCart(string id)
        {
            string message;
            var course = db.Courses.SingleOrDefault(s => s.Id == id);
            var result = GetCart().Add(course);
            if (result)
            {
                message = "Add course success";
            }
            else
            {
                message = "Course already in cart";
            }

            return Json(new
            {
                result = result,
                message = message
            });
        }

        public ActionResult BuyNow (string id)
        {
            var course = db.Courses.SingleOrDefault(s => s.Id == id);
            var result = GetCart().Add(course);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {
                return View();
            }

            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult RemoveCart(string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveCartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
    }
}