using Entities.Concrete;
using Entities.DTOs;

namespace UI.ViewModels
{
    public class CarVM
    {
        public List<CarImage> CarImageGetById { get; set; }
        public Car CarGetById { get; set; }
    }
}
