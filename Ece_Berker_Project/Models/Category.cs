using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public virtual List<Yorum> Yorums { get; set; }
    }
}
