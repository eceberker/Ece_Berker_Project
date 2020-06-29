using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.ViewModel
{
    public class SearchViewModel
    {
        public string SearchText { get; set; }
        public string Username { get; set; }
        public int? CategoryId { get; set; }
        public List<Models.Yorum> Results { get; set; }

    }
}
