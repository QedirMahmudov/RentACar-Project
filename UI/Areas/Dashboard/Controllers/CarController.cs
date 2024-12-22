using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Dashboard.Controllers
{
    [Area("AdminDashboard")]
    public class CarController : Controller
    {
        private readonly ICarImageService _carImageService;
        private readonly ICarService _carService;

        public CarController(ICarImageService carImageService, ICarService carService)
        {
            _carImageService = carImageService;
            _carService = carService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CarImageAddDto carImage)
        {
            try
            {
                _carImageService.AddCarImage(carImage);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();

            }
        }
    }
}
