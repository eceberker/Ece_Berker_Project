using Ece_Berker_Project.Data;
using Ece_Berker_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ece_Berker_Project.Services
{
    public class YorumService : IYorum
    {
        private readonly ApplicationDbContext _context;
        
        public YorumService (ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Add(Yorum yorum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Yorum> GetAll()
        {
          return _context.Yorums.Include(y => y.Category).Include(u => u.User).OrderByDescending(p => p.PostDate);
        }

        public Yorum GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Yorum> Profile(string id)
        {
            var yorum = _context.Yorums.Include(c => c.Category).AsQueryable().OrderByDescending(p => p.PostDate);

            if (id != null)
            {
                yorum = _context.Yorums.Where(y => y.User.UserCode == id).Include(y => y.User).Include(y => y.Category)
             .OrderByDescending(p => p.PostDate);

                
            }
            else
            {
                yorum =  _context.Yorums.Include(y => y.User).Include(y => y.Category)
                .OrderByDescending(p => p.PostDate);
                
            }
            return yorum;
        }

        public IEnumerable<Yorum> Search(string SearchText, int? CategoryId, string Username)
        {
            var yorum = _context.Yorums.Include(c=>c.Category).AsQueryable().OrderByDescending(p => p.PostDate);

        
            if (!String.IsNullOrWhiteSpace(SearchText))
             {
             yorum = yorum.Where(y=>y.Title.Contains(SearchText)).Include(y => y.User).OrderByDescending(p => p.PostDate);
             }
      
           
            if (CategoryId.HasValue)
             {
              yorum = yorum.Where(y => y.CategoryId == CategoryId.Value).Include(y => y.User).OrderByDescending(p => p.PostDate);
             }
       
           
            if (!String.IsNullOrEmpty(Username))
            {
                yorum = yorum.Where(y => y.UserName.Contains(Username)).Include(u => u.User).OrderByDescending(p => p.PostDate);
            }
          
           
            if (SearchText == null && CategoryId == null &&  Username == null)
            {
               yorum = _context.Yorums.Include(c => c.Category).Include(y => y.User).AsQueryable().OrderByDescending(p => p.PostDate); 
            }

            return yorum;
        }
    }
}
