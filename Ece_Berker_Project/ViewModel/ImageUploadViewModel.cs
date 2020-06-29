using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class ImageUploadViewModel
    {
        public int userId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
