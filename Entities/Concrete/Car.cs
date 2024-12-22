using Entities.Abstract;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Car : BaseEntity
	{
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int CategoryId { get; set; }
        public double CarPrice { get; set; }
        public string Color { get; set; }
        public double CarKM { get; set; }
        public short CarYear { get; set; }
        public string transmissionType { get; set; }
		public string Fuel { get; set; }
        public int CC { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public string ImageUrl { get; set; }
    }
}
