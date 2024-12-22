using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace UI.Controllers
{
    public class CarController : Controller
    {
        private readonly RentACarContext _sql;
        //private readonly ICarImageService _carImageService;
        private readonly ICarService _carService;

        public CarController(/*ICarImageService carImageService*//*,*/ ICarService carService, RentACarContext sql)
        {
            //_carImageService = carImageService;
            _carService = carService;
            _sql = sql;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCar()
        {
            ViewBag.Category = new SelectList( _sql.Categories.Where(c => c.IsActive == true).ToList(),"Id", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Car car, IFormFile ImageUrl)
        {
            string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(ImageUrl.FileName);
            using (Stream stream = new FileStream("wwwroot/images/carimg/" + filename, FileMode.Create))
            {
                ImageUrl.CopyTo(stream);
            }
            car.ImageUrl = filename;
            _sql.Cars.Add(car);
            _sql.SaveChanges();
            return RedirectToAction("Listing", "Home");
        }

        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _sql.Categories.Add(category);
            _sql.SaveChanges();
            return RedirectToAction("Listing", "Home");
        }


        public IActionResult DeleteCar(int id)
        {
            var deleteCar = _sql.Cars.SingleOrDefault(x => x.Id == id && x.IsActive == true);
            deleteCar.IsActive = false;
            _sql.SaveChanges();
            return RedirectToAction("Listing", "Home");
        }
        public IActionResult UpdateCar(int id)
        {
            var a = _sql.Cars.SingleOrDefault(x => x.Id == id);
            return View(a);
        }
        [HttpPost]
        public IActionResult UpdateCar(int id, Car car, IFormFile ImageUrl)
        {
            var oldphoto = _sql.Cars.SingleOrDefault(x => x.Id == id);
            using (Stream stream = new FileStream("wwwroot/images/carimg/" + oldphoto.ImageUrl, FileMode.Create))
            {
                ImageUrl.CopyTo(stream);
            }
            oldphoto.CarBrand = car.CarBrand;
            oldphoto.CarModel = car.CarModel;
            oldphoto.CarPrice = car.CarPrice;
            oldphoto.Color = car.Color;
            oldphoto.CarKM = car.CarKM;
            oldphoto.CarYear = car.CarYear;
            oldphoto.transmissionType = car.transmissionType;
            oldphoto.Fuel = car.Fuel;
            oldphoto.CC = car.CC;
            oldphoto.Description = car.Description;
            _sql.SaveChanges();
            return RedirectToAction("Listing", "Home");
        }
        public IActionResult UpdateCategory(int id)
        {
            var category = _sql.Categories.SingleOrDefault(x => x.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult UpdateCategory(int id, Category category)
        {
            ViewBag.Category = _sql.Categories.SingleOrDefault(c => c.Id == id && c.IsActive == true);
            if (category != ViewBag.Category)
            {
                ViewBag.Category.CategoryName = category.CategoryName;
                _sql.SaveChanges();
            }
            //ViewBag.Category = _sql.Categories.Where(c => c.IsActive == true).ToList();
            return RedirectToAction("Listing", "Home");
        }

        public IActionResult RentNow(int id)
        {
            var rentACar = _sql.Cars.SingleOrDefault(x => x.Id == id);
            return View(rentACar);
        }

        //[HttpPost]
        //public IActionResult AddCar(Car car)
        //{
        //    using (var context=  new RentACarContext())
        //    {
        //        context.Cars.Add(car);
        //        context.SaveChanges();
        //    }
        //    return View();
        //}

        //public IActionResult Detail(int id)
        //{
        //    var carData = _carService.Get(id).Data;
        //    var carImageData = _carImageService.GetCarImageById(id).Data;
        //    CarVM carVM = new()
        //    {
        //        CarGetById = carData,
        //        CarImageGetById = carImageData
        //    };

        //    if (carData != null && carImageData != null)
        //    {
        //        return View(carVM);
        //    }
        //    else
        //    {
        //        return NotFound();  
        //    }
        //}



        //public IActionResult Edit(int id)
        //{
        //    using (var item = new RentACarContext())
        //    {
        //        var a = item.Cars.SingleOrDefault(x => x.Id == id);
        //        return View(a);

        //    }
        //}


        //[HttpPost]
        //public IActionResult Edit(int id, Car car)
        //{
        //    using (var item = new RentACarContext())
        //    {
        //        var a = item.Cars.SingleOrDefault(x => x.Id == id);
        //        if (a != null)
        //        {
        //            a.CarBrand = car.CarBrand;
        //            a.CarModel = car.CarModel;
        //            a.CarPrice = car.CarPrice;
        //            a.Color = car.Color;
        //            a.CarKM = car.CarKM;
        //            a.CarYear = car.CarYear;
        //            a.transmissionType = car.transmissionType;
        //            a.Fuel = car.Fuel;
        //            a.CC = car.CC;
        //            a.Description = car.Description;
        //            a.ImageUrl = car.ImageUrl;
        //            item.SaveChanges();
        //        }
        //        return RedirectToAction("Index", "Home");
        //    }
        //}


    }
}
