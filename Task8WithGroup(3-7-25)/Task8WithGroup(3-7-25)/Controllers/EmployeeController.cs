using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task8WithGroup_3_7_25_.Models;

namespace Task8WithGroup_3_7_25_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _db;

        public EmployeeController(MyDbContext db)
        {
            _db = db;
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var employee = _db.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employee != null)
            {
                HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                return RedirectToAction("Home");
            }


            ViewBag.msg = "Invalid Email or Password";
            return View();

        }//CREATE


        public IActionResult Home()
        {
            int? employeeId = HttpContext.Session.GetInt32("EmployeeId");

            var tasks = _db.EmpTasks.Where(t => t.EmployeeId == employeeId).ToList();

            return View(tasks);
        }

        public IActionResult ChangeStatus(int id)
        {
            ViewBag.taskid=id;
            var task =_db.EmpTasks.Find(id);

            return View(task);

        }
        [HttpPost]
        public IActionResult ChangeStatus(int id ,string newstatus) {

            var task = _db.EmpTasks.Find(id);

            task.Status= newstatus;
            _db.Update(task);
            _db.SaveChanges();

            return RedirectToAction("Home");
        
        }


        public ActionResult Profile() {
            int? employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employee = _db.Employees.Find(employeeId);
            return View(employee);

        }


        public IActionResult EditProfile() {

            int? employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employee = _db.Employees.Find(employeeId);
            return View(employee);

        }
        [HttpPost]
        public IActionResult EditProfile(Employee updatedEmployee)
        {
            int? employeeId = HttpContext.Session.GetInt32("EmployeeId");
            var employee = _db.Employees.Find(employeeId);

            if (employee != null)
            {
                employee.FullName = updatedEmployee.FullName;
                employee.Email = updatedEmployee.Email;
                employee.Password = updatedEmployee.Password;
                employee.ProfileImage = updatedEmployee.ProfileImage;

                _db.SaveChanges();


            }



            //_db.Employees.Update(updatedEmployee);
           
            return RedirectToAction("Profile");

        }

    }
    }
