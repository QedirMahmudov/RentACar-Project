using Azure;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly RentACarContext _sql;
        private readonly ICarService _carService;
        private readonly ITestimonialService _testimonialService;
        public HomeController(ICarService carService, RentACarContext sql, ITestimonialService testimonialService)
        {
            _carService = carService;
            _sql = sql;
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            ViewBag.Testimonials = _sql.Testimonials.Where(T => T.IsActive == true).Take(6).ToList();
            ViewBag.Cars = _sql.Cars.Where(c => c.IsActive == true).Take(6).ToList();
            ViewBag.Category = _sql.Categories.Where(c => c.IsActive == true).ToList();
            return View();
        }

        public IActionResult Listing(int page= 0)
        {
            ViewBag.Testimonials = _sql.Testimonials.Where(T => T.IsActive == true).Take(3).ToList();
            ViewBag.Brand = _sql.Cars.Where(b => b.IsActive == true).Select(b => b.CarBrand).Distinct().ToList();
            ViewBag.Model = _sql.Cars.Where(m => m.IsActive == true).Select(m => m.CarModel).Distinct().ToList();
            ViewBag.Category = _sql.Categories.Where(c => c.IsActive == true).ToList();
            var cars = _carService.GetAll();
            ViewBag.PageCount = _sql.Blogs.Count() / 6;
            if (page < 0)
            {
                return RedirectToAction("Listing", "Home");
            }
            return View(cars.Data.Where(car => car.IsActive == true).Skip(page*6).Take(6).ToList());
        }
        public IActionResult Testimonials(int page = 0)
        {
            ViewBag.PageCount = _sql.Blogs.Count() / 3;
            if (page < 0)
            {
                return RedirectToAction("Listing", "Home");
            }

            return View(_sql.Testimonials.Where(i=>i.IsActive==true).Skip(page * 3).Take(3).ToList());


        }


        public IActionResult Blog(int page = 0)
        {
            ViewBag.PageCount = _sql.Blogs.Count() / 3;
            if (page<0)
            {
                return RedirectToAction("Blog","Home");
            }
            return View(_sql.Blogs.Where(b => b.IsActive == true).Skip(page * 3).Take(3).ToList());
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
