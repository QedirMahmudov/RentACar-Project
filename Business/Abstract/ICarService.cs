using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(int id);
		IDataResult<Car> Get(int id);
		IDataResult<List<Car>> GetAll();
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<Car>> PriceFilter(double minPrice, double maxPrice);

	}
}
