using Ece_Berker_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ece_Berker_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext <YorumluoUser>
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
    }
}
