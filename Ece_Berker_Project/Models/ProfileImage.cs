using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Models
{
    public class ProfileImage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public virtual YorumluoUser User { get; set; }
    }
}
