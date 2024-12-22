using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Testimonial : BaseEntity
	{
        public string PhotoUrl { get; set; }
        public string TestimonialFullName { get; set; }
        public string TestimonialPosition { get; set; }
        public string TestimonialComment { get; set; }
    }
}
