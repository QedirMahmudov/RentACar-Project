using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Blog : BaseEntity
	{
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }

    }
}
