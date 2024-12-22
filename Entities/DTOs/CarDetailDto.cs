using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class CarDetailDto : IDto
	{
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public double RentPrice { get; set; }
        public short CarYear { get; set; }
        public string transmissionType { get; set; }
        public int CC { get; set; }
    } 
}
