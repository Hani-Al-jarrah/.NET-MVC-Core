using Microsoft.AspNetCore.Mvc;
using WebApp_Model__23_2__ONSITE_.Models;

namespace WebApp_Model__23_2__ONSITE_.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly MyDbContext _context;

        public DepartmentController(MyDbContext context) { 
        
            _context = context;
        }



        public IActionResult Index()
        {
            //var dep=_context.Departments.ToList();
            //return View(dep);

            //return View(_context.Departments.ToList());

            return View(_context.Departments);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);

            //_context.Add(department);

            _context.SaveChanges();
            return RedirectToAction("Index");

            //return View(department);
        }







    }
}
