using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Model__23_2__ONSITE_.Models;

namespace WebApp_Model__23_2__ONSITE_.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _db;

        public ProductController(MyDbContext db) { 
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            return View(_db.Products.Find(id));
        }





        public IActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }







        [HttpPost]
        public IActionResult Delete(int id)
        {
            var  product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
