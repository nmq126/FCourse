using FCourse.Data;
using FCourse.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FCourse.Controllers
{
    public class UserController : Controller
    {
        private Data.DBContext myIdentityDbContext;
        private UserManager<User> userManager;
        private RoleManager<Role> roleManager;

        // GET: User
        public UserController()
        {
            myIdentityDbContext = new Data.DBContext();
            UserStore<User> userStore = new UserStore<User>(myIdentityDbContext);
            userManager = new UserManager<User>(userStore);
            RoleStore<Role> roleStore = new RoleStore<Role>(myIdentityDbContext);
            roleManager = new RoleManager<Role>(roleStore);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User user)
        {
            user.DisabledAt = user.UpdatedAt = user.CreatedAt = DateTime.Now;
            user.Status = 1;
            try
            {
                var result = await userManager.CreateAsync(user, user.Password);
                if (result.Succeeded)
                {
                    return Redirect("/User/Login");
                }
                else
                {
                    return View("ViewError");
                }

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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddRole(string RoleName)
        {
            Role role = new Role()
            {
                Name = RoleName
            };
            var result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return View("ViewSucceeded");
            }
            else
            {
                return View("ViewError");
            }
        }
        public async Task<ActionResult> AddUserToRole(string UserId, string RoleId)
        {
            var user = myIdentityDbContext.Users.Find(UserId);
            var role = myIdentityDbContext.Roles.Find(RoleId);
            if (role == null || user == null)
            {
                return View("ViewError");
            }
            var result = await userManager.AddToRoleAsync(user.Id, role.Name);
            if (result.Succeeded)
            {
                return View("ViewSucceeded");
            }
            else
            {
                return View("ViewError");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindAsync(UserName, Password);
                if (user == null)
                {
                    ModelState.AddModelError("LoginError", "The user name or password provided is incorrect.");
                    return View();
                }
                else
                {
                    SignInManager<User, string> signInManager = new SignInManager<User, string>(userManager, Request.GetOwinContext().Authentication);
                    await signInManager.SignInAsync(user, false, false);

                    return Redirect("/Home");
                }
            }
           
            return RedirectToAction("Login");
        }

        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
    }
}