using Ece_Berker_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Data
{
   public interface IYorum
    {
        Yorum GetById(int id);
        IEnumerable<Yorum> GetAll();
        IEnumerable<Yorum> Search(string SearchText, int? CategoryId, string UserName);


    }
}
