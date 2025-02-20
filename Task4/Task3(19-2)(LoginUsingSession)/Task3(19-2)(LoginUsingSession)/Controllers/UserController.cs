using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace Task3_19_2__LoginUsingSession_.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleRegister(string name, string email, string password, string repassword)
        {

            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("Password", password);
            HttpContext.Session.SetString("RePassword", repassword);


            if (password != repassword)
            {
                TempData["MSG"] = "Password doesn't match";
                return RedirectToAction("Register");

            }

            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HandleLogin(string email, string password ,string rem)
        {
            var Email =  HttpContext.Session.GetString("Email");
            var Password = HttpContext.Session.GetString("Password");

            if (rem != null)
            {
                CookieOptions obj = new CookieOptions();
                obj.Expires = DateTime.Now.AddDays(2);
                //store
                Response.Cookies.Append("userInfo", email, obj);
            }


            if (email == "Admin@gmail.com" && password == "Admin")
            {
                HttpContext.Session.SetString("Email", "Admin@gmail.com");
                HttpContext.Session.SetString("Password", "Admin");


                HttpContext.Session.SetString("adminLogin", "Admin");//aljawahra

                return RedirectToAction("Index", "Home");
            }

            if (email ==Email && password == Password) {
                HttpContext.Session.SetString("adminLogin", "User");

                return RedirectToAction("Index", "Home");
            }

            TempData["MSG2"] = "Password or Email not valid";
            return RedirectToAction("Login");

          
        }

        [HttpPost]
        public IActionResult HandleEdit(string address, string phone)
        {
          

          
            HttpContext.Session.SetString("Address", address);
            HttpContext.Session.SetString("Phone", phone);

            return RedirectToAction("Profile");
        }

        public IActionResult Profile()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            ViewBag.Address = HttpContext.Session.GetString("Address");
            ViewBag.Phone = HttpContext.Session.GetString("Phone");

            return View();
        }
        public IActionResult Admin()
        {

            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Password = HttpContext.Session.GetString("Password");

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
