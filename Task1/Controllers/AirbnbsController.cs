using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class AirbnbsController : Controller
    {
        public IActionResult Airbnbs()
        {
            return View();
        } 
        public IActionResult Detailes()
        {
            return View();
        }
    }
}
