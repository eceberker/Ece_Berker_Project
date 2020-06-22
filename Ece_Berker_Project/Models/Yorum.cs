using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public string ContentText;
        public string UserName { get; set; }

        public int Likes { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime PostDate { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public Yorum()
        {
            PostDate = DateTime.Now;
        }
    }

}
