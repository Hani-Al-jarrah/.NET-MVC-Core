using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class ToursController : Controller
    {
        public IActionResult Tours()
        {
            return View();
        }

        public IActionResult Detailes()
        {
            return View();
        }

    }
}
