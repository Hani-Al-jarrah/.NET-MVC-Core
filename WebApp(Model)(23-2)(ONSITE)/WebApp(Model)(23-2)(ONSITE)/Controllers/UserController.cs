using Microsoft.AspNetCore.Mvc;
using WebApp_Model__23_2__ONSITE_.Models;

namespace WebApp_Model__23_2__ONSITE_.Controllers
{
    public class UserController : Controller
    {
        private  MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        // Display all users
        public IActionResult Index()
        {
            var users = _context.Users;
            return View(users);
        }

        // Show form to create a new user
        public IActionResult Create()
        {
            return View();
        }

        // Add new user to database
        [HttpPost]
        public IActionResult Create(User user)
        {
           
                _context.Users.Add(user);
                _context.SaveChanges();
                 return View(user);
        }
    }
}
