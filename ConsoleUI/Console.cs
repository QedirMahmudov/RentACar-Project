using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

CarManager carManager = new(new EFCarDal(new RentACarContext()));
//EFCarDal CarDal = new EFCarDal();

//foreach (var car in carManager.GetCarDetails())
//{
//    Console.WriteLine(car.CarName+ "---" + car.CategoryName );
//}


//foreach (var filterPriceCar in CarDal.PriceFilter(20000, 30000))
//{
//    Console.WriteLine(filterPriceCar.CarBrand + "---" + filterPriceCar.CarPrice);
//}