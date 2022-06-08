using FCourse.Data;
using FCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayPal.Api;
using Order = FCourse.Models.Order;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;
using System.Diagnostics;

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

        public ActionResult BuyNow(string id)
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

        //Paypal
        private Payment payment;

        //Create Payment
        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            Cart listCarts = Session["Cart"] as Cart;
            foreach (var cart in listCarts.Items)
            {
                listItems.items.Add(new Item()
                {
                    name = cart.course.Name,
                    currency = "USD",
                    price = cart.course.Price.ToString(),
                    quantity = "1",
                    sku = "sku"
                });
            }
            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = listCarts.Items.Sum(s => s.course.Price * (1 - s.course.Discount / 100)).ToString()
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "FCourse transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        //Excute Payment
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        //Payment with paypal
        public ActionResult PaymentWithPaypal()
        {
            if (User.Identity.IsAuthenticated)
            {
                APIContext apiContext = PaypalConfiguration.GetAPIContext();
                try
                {
                    string payerId = Request.Params["PayerID"];
                    if (string.IsNullOrEmpty(payerId))
                    {
                        string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPaypal?";
                        var guid = Convert.ToString((new Random()).Next(100000));
                        var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid);
                        var links = createdPayment.links.GetEnumerator();
                        string paypalRedirectUrl = string.Empty;

                        while (links.MoveNext())
                        {
                            Links link = links.Current;
                            if (link.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                paypalRedirectUrl = link.href;
                            }
                        }

                        Session.Add(guid, createdPayment.id);
                        return Redirect(paypalRedirectUrl);
                    }
                    else
                    {
                        var guid = Request.Params["guid"];
                        var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                        if (executedPayment.state.ToLower() != "approved")
                        {
                            Session.Remove("Cart");
                            return View("~/Views/Home/Error_404.cshtml");
                        }
                    }
                }
                catch (Exception e)
                {
                    PaypalLogger.Log("Error: " + e.Message);
                    Session.Remove("Cart");
                    return View("~/Views/Home/Error_404.cshtml");
                }

            //Add new order
            var listItems = new ItemList() { items = new List<Item>() };
            Cart listCarts = Session["Cart"] as Cart;
            string userId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var order = new Order()
            {
                Id = String.Concat("ORD_", Guid.NewGuid().ToString("N").Substring(0, 5)),
                UserId = userId,
                TotalPrice = Convert.ToString(listCarts.Items.Sum(s => s.course.Price * (1 - s.course.Discount / 100)).ToString()),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DisabledAt = DateTime.Now,
                Status = 1
            };
            db.Orders.Add(order);
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            //Add order details
            
            foreach (var cart in listCarts.Items)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    CourseId = cart.course.Id,
                    UnitPrice = cart.course.Price
                };
                UserCourse userCourse = new UserCourse()
                {
                    CourseId = cart.course.Id,
                    UserId = userId,
                    Grade = null,
                    IsFinished = false
                };
                List<Section> sections = db.Sections.Where(s => s.CourseId == cart.course.Id).ToList();
                if (sections != null && sections.Count() >0)
                {
                    foreach (var section in sections)
                        {
                            UserSection userSection = new UserSection()
                            {
                                UserId = userId,
                                SectionId = section.Id,
                                PausedAt = 0,
                                IsFinished = false
                            };
                            db.UserSections.Add(userSection);
                        }
                }

                db.OrderDetails.Add(orderDetail);
                db.UserCourses.Add(userCourse);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

                Session.Remove("Cart");
                return View("~/Views/Home/ThankYou.cshtml");
            }
            else
            {
                TempData["data"] = "You must login before payment.";
                return RedirectToAction("Login", "User");
            }
        }
    }
}