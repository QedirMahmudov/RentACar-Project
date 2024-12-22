using Business.Concrete;
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
    public interface ICarImageService
    {
        IResult AddCarImage(CarImageAddDto carImageAddDto);
        IDataResult<List<CarImageToCarDto>> GetAllCarImagesByFeatured();
        IDataResult<List<CarImage>> GetCarImageById(int carId);

    }
}
