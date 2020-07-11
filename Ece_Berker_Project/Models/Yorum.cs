using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Yorum
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Yorum")]
        public string Title { get; set; }
        public string ContentText;
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        public int? Likes { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Kategori Adı")]
        public Category Category { get; set; }
        public DateTime PostDate { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual YorumluoUser User { get; set; }
        public List<UserLikes> LikedUser { get; set; }

        [NotMapped]
        public bool IsLiked { get; set; }
        public Yorum()
        {
            PostDate = DateTime.Now;
        }


    }

}
