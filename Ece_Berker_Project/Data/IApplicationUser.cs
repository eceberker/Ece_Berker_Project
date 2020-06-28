using Ece_Berker_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Data
{
    public interface IApplicationUser
    {
        YorumluoUser GetById(string id);
        IEnumerable<YorumluoUser> GetAll();
        
    }
}
