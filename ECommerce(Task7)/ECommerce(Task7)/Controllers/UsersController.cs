using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerce_Task7_.Models;

namespace ECommerce_Task7_.Controllers
{
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        //// GET: Users
        public  IActionResult Index()
        {
            return View(_context.Products.ToList());
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public IActionResult Create() // Register
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Role")] User user)
        {
            
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            
            return View(user);
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user/*,  string Email , string Password*/)
        {
            var userinfo = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (userinfo!=null) {

                HttpContext.Session.SetString("UserName", userinfo.Name);
                HttpContext.Session.SetString("UserRole", userinfo.Role);
                HttpContext.Session.SetString("UserEmail", userinfo.Email);

                if (userinfo.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Products");
                }
                return RedirectToAction("Index", "Users");

            }


            ViewBag.Msg1 = "Invalid Email or Password";
            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }




        public IActionResult Profile()
        {

        

            var email = HttpContext.Session.GetString("UserEmail");

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }


        
        public IActionResult EditProfile()
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            return View(user);
        }


        [HttpPost]
        public IActionResult EditProfile(User updateuser)
        {
            var email = HttpContext.Session.GetString("UserEmail");


            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            user.Name = updateuser.Name;
            user.Email = updateuser.Email;
            _context.SaveChanges();
            HttpContext.Session.SetString("UserEmail", updateuser.Email);
            ViewBag.msg2 = "Update seccessfully";

            return RedirectToAction("Profile");
        }
        













        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Role")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }








        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
