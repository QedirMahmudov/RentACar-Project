using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageToCarDto : IDto
    {
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public double RentPrice { get; set; }
        public short CarYear { get; set; }
        public string transmissionType { get; set; }
        public int CC { get; set; }
        public int CategoryId { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
        public int CarImageId { get; set; }
        public string Description { get; set; }
    }
}
