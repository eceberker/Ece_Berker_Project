using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı boş bırakılamaz.")]
        [Display(Name = "Kategori Adı") ]
        public string Name { get; set; }
        public virtual List<Yorum> Yorums { get; set; }
    }
}
