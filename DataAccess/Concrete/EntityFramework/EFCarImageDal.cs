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
    public class EFCarImageDal : EFEntityRepository<CarImage, RentACarContext>,ICarImageDal
    {
        public EFCarImageDal(RentACarContext context) : base(context)
        {
        }

        public List<CarImageToCarDto> GetAllCarsByFeatured()
        {
            RentACarContext context = new();
            var result = from i in context.CarImages
                         where i.IsActive == true
                         join c in context.Cars
                         on i.CarId equals c.Id
                         select new CarImageToCarDto
                         {
                             CarId = c.Id,
                             IsFeatured = c.IsFeatured,
                             PhotoUrl = i.PhotoUrl,
                             Description = c.Description,
                             CarBrand = c.CarBrand,
                             CarModel = c.CarModel,
                             CarYear = c.CarYear,
                             CC = c.CC,
                             RentPrice = c.CarPrice,
                             transmissionType = c.transmissionType
                         };
            //return result.ToList();

            return result.Where(c => c.IsFeatured == true).Take(6).ToList();
        }
    }
}
