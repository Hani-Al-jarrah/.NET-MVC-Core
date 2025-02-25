using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.Intrinsics.X86;
using WebApp_Model__23_2__ONSITE_.Models;

namespace WebApp_Model__23_2__ONSITE_.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }





        //public IActionResult Index()
        //{
        //    return View(_context.Users.ToList()); //// Blocks the thread
        //}

        public async Task<IActionResult> Index() //used to handle asynchronous operations efficiently. //// Non-blocking
        {
            var users = await _context.Users.ToListAsync(); //Prevents the UI from freezing by allowing non-blocking execution. | Frees up the server’s resources to handle multiple requests.
            return View(users);
        } // why we use it :: Improves application performance and responsiveness.

        public IActionResult Create()
        {
            return View();
        }







        [HttpPost]
        public IActionResult Create(User user)
        {
           
                _context.Users.Add(user);
                _context.SaveChanges();
                return View(user);
        }







        public IActionResult Details(int id)
        {
            return View(_context.Users.Find(id));
        }





        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }







        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id); //Searches only by primary key. | _context.Users.Find(1); // Finds user with ID = 1
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // Use Find() when searching by primary key.
        // Use FirstOrDefault() when filtering by other columns.


            



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Prevents malicious users from sending fake requests from external websites.
        public IActionResult Register(User user)  //checks if the model (data) sent from the form is valid based on validation rules.
        {
            if (ModelState.IsValid) // Checks if all required fields are valid
            {

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            } // Show errors if validation fails


            ViewBag.ErrorMessage = "Please fill in all required fields correctly.";

            return View(user);
        }


       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(User => User.Email == email && User.Password == password); //Searches using any condition. & Checks multiple columns.

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);
                return RedirectToAction("Home");
            }

            ViewBag.Error = "Invalid Email or Password!";
            return View();
        }


        public IActionResult Dashboard()
        {
            var users = _context.Users.ToList(); // List all users
            return View(users);
        }


        //[HttpPost]
        //public IActionResult Login(User user)
        //{
        //    return View(_context.Users.Find(id));

        //}

        public IActionResult Home()
        {
            var name = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Login");
            }

            ViewBag.name = name;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login"); 
        }


    }
}
