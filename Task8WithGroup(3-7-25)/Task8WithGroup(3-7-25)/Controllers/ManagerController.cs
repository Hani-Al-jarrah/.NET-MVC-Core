using Microsoft.AspNetCore.Mvc;
using Task8WithGroup_3_7_25_.Models;

namespace Task8WithGroup_3_7_25_.Controllers
{
    public class ManagerController : Controller
    {

        private readonly MyDbContext _db;

        public ManagerController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email , string password) {
         var manager =    _db.Managers.FirstOrDefault(m => m.Email == email && m.Password == password);

            if (manager != null)
            {
                HttpContext.Session.SetInt32("ManagerId" , manager.ManagerId);
                return RedirectToAction("Home");
            }

            ViewBag.msg = "Invalid Email or Password";
            return View();

        }//CREATE



        public IActionResult Home() {
            int? managerId = HttpContext.Session.GetInt32("ManagerId");

            var employees = _db.Employees.Where(e => e.ManagerId==managerId).ToList();


            if (managerId == null ) { return RedirectToAction("Login"); }

            return View(employees);        
        }//READ LIST of Employees
        public IActionResult ViewTask(int employeeId)
        {
            var tasks = _db.EmpTasks.Where(t => t.EmployeeId == employeeId).ToList();

            return View(tasks);
        }//READ LIST of TASKS


        [HttpGet]
        public IActionResult AddEmployee()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.EmployeeId = 0;
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Home");


        }

        [HttpGet]
        public ActionResult AssignTask(int EmployeeId) {
            
            ViewBag.EmployeeId= EmployeeId;
        
        return View();
        
        }
        [HttpPost]
        public ActionResult AssignTask(EmpTask empTask)
        {
        
            empTask.TaskId = 0; 
            _db.EmpTasks.Add(empTask);
            _db.SaveChanges();
            return RedirectToAction("Home");


        }

    }
}
