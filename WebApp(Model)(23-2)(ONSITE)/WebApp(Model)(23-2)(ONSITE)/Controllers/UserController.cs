using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

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
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
