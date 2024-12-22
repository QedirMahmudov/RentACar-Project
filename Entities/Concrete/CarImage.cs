using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CarImage : BaseEntity
    {
        public int CarId { get; set; }
        public bool IsFeatured { get; set; }
        public string PhotoUrl { get; set; }
    }
}
