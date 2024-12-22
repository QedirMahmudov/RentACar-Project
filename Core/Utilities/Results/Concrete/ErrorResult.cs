using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
	public class ErrorResult : Result
	{
        public ErrorResult() : base(false)
        {
            
        }
        public ErrorResult(string message) : base(false,message)
        {
            
        }
        public ErrorResult(bool success,string message) : base(success,message)
        {
            
        }
    }
}
