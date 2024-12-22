using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public interface IAddPhotoHelperService
    {
        void AddImage(IFormFile formFile, string guid);
    }
}
