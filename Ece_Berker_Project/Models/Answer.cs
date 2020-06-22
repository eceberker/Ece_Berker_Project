using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime PostDate { get; set; }
        public int YorumId { get; set; }
        public Yorum Yorum { get; set; }
        public Answer()
        {
            PostDate = DateTime.Now;
        }
    }
}
