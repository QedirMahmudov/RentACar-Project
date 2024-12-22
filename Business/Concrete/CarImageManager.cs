using Business.Abstract;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    //public class CarImageManager(ICarImageDal carImageDal, IAddPhotoHelperService photoHelperService) : ICarImageService
    //{
    //    private readonly ICarImageDal _carImageDal = carImageDal;
    //    private readonly IAddPhotoHelperService _photoHelperService = photoHelperService;

    //    public IResult AddCarImage(CarImageAddDto carImageAddDto)
    //    {
    //        var guid = Guid.NewGuid() + "-" + carImageAddDto.Photo.FileName;
    //        _photoHelperService.AddImage(carImageAddDto.Photo, guid);
    //        CarImage carImage = new()
    //        {
    //            CarId = carImageAddDto.CarId,
    //            PhotoUrl = "/images/" + guid
    //        };
    //        _carImageDal.Add(carImage);
    //        return new SuccessResult("Car image is added!");
    //    }

    //    public IDataResult<List<CarImageToCarDto>> GetAllCarImagesByFeatured()
    //    {
    //        var result = _carImageDal.GetAllCarsByFeatured();
    //        if (result != null && result.Count > 0)
    //        {
    //            return new SuccessDataResult<List<CarImageToCarDto>>(result, "Featured cars found");
    //        }
    //        else
    //        {
    //            return new ErrorDataResult<List<CarImageToCarDto>>(result, "No featured cars found");
    //        }
    //    }

    //    public IDataResult<List<CarImage>> GetCarImageById(int carId)
    //    {
    //        var result = _carImageDal.Get(i => i.CarId == carId);
    //        if (result != null)
    //        {
    //            return new SuccessDataResult<List<CarImage>>("found");
    //        }
    //        else
    //        {
    //            return new ErrorDataResult<List<CarImage>>("Not found");
    //        }
    //    }
    //}
}

