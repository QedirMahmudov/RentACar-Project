using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
	public class CarManager(ICarDal carDal) : ICarService
	{
		private readonly ICarDal _carDal = carDal;


		[ValidationAspect<Car>(typeof(CarValidation))]
		//[PerformanceAspect(5)]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult("Car was Added!");
		}

		public IResult Delete(int id)
		{
			Car deleteCar = null;
			Car resultCar = _carDal.Get(c => c.Id == id && c.IsActive == true);
			if (resultCar != null) deleteCar = resultCar;
			deleteCar.IsActive = false;
			_carDal.Delete(deleteCar);
			return new SuccessResult("Car was deleted!");
		}

		public IDataResult<Car> Get(int id)
		{
			Car getCar = _carDal.Get(c=>c.Id == id);
            if (getCar != null)
				return new SuccessDataResult<Car>(getCar, "Cars Successfully Loaded!");

			else
				return new ErrorDataResult<Car>("Car not found!");
		}

		public IDataResult<List<Car>> GetAll()
		{
			var getAllCar = _carDal.GetAll(c=>c.IsActive == true);
			if (getAllCar.Count > 0)
				return new SuccessDataResult<List<Car>>(getAllCar, "Cars Successfully Loaded!");
			else
				return new ErrorDataResult<List<Car>>("Car not found!");
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			var getCarDetails = _carDal.GetCarDetails();
			return new SuccessDataResult<List<CarDetailDto>>(getCarDetails, "Cars Successfully Loaded!");

		}

		public IDataResult<List<Car>> PriceFilter(double minPrice, double maxPrice)
		{
			var filterCars = _carDal.GetAll().Where(c => c.CarPrice >= minPrice && c.CarPrice <= maxPrice && c.IsActive == true).ToList();
			if (filterCars.Count > 0)
			{
				return new SuccessDataResult<List<Car>>(filterCars, "Cars Successfully Loaded!");
			}
			return new ErrorDataResult<List<Car>>("No car found in the price range!");
		}

		public IResult Update(Car car)
		{
			Car updateCar = _carDal.Get(c=>c.Id == car.Id && c.IsActive == true);
			if (updateCar == null)
			{
				return new ErrorResult("Car not found or is not active.");
			}
			updateCar.CarBrand = car.CarBrand;
				updateCar.CarModel = car.CarModel;
				updateCar.CarPrice = car.CarPrice;
				updateCar.Color = car.Color;
				updateCar.CarKM = car.CarKM;
				updateCar.CarYear = car.CarYear;
				updateCar.transmissionType = car.transmissionType;
				updateCar.Fuel = car.Fuel;
				updateCar.CC = car.CC;
				updateCar.Description = car.Description;
				_carDal.Update(updateCar);
				return new SuccessResult("Car was Update!");
		}
	}
}
