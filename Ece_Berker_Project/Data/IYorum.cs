using Ece_Berker_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Data
{
    interface IYorum
    {
        Task Post(Yorum yorum);
    }
}
