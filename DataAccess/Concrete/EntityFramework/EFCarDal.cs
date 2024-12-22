using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EFCarDal : EFEntityRepository<Car, RentACarContext>, ICarDal
	{
		public EFCarDal(RentACarContext context) : base(context)
		{
		}

		public List<CarDetailDto> GetCarDetails()
		{
			using (RentACarContext context = new())
			{
				var result = from C in context.Cars
							 where C.IsActive == true
							 join c in context.Categories
							 on C.CategoryId equals c.Id 
							 select new CarDetailDto
							 {
								  CarBrand = C.CarBrand,
								  CarModel = C.CarModel,
								  RentPrice = C.CarPrice,
								  CarYear = C.CarYear,
								  transmissionType = C.transmissionType,
								  CC = C.CC
							 };
				return result.ToList();
			}
		}
		
	}
}
