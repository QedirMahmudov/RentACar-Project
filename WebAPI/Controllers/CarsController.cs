using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController(ICarService carService) : ControllerBase
	{
		private readonly ICarService _carService = carService;
		[HttpPost("AddCar")]
		public IActionResult AddCar(Car car)
		{
			var result = _carService.Add(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("DeleteCar")]
		public IActionResult Delete(int id)
		{
			var result = _carService.Delete(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetById")]
		public IActionResult Get(int id)
		{
			var result = _carService.Get(id);
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("PriceFilter")]
		public IActionResult FilterPrice(double minPrice, double maxPrice)
		{
			var result = _carService.PriceFilter(minPrice, maxPrice);
			return Ok(result);
		}


		[HttpGet("RentACarDetails")]
		public IActionResult RentACarDetails()
		{
			var result = _carService.GetCarDetails();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}



		[HttpGet("GetAllCars")]
		public IActionResult GetAll()
		{
			var result = _carService.GetAll();
			if (result != null)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}


		[HttpPost("UpdateCar")]
		public IActionResult UpdateCar(Car id)
		{
			var result = _carService.Update(id);

			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
