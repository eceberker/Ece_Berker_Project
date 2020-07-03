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
        public DbSet<YorumluoUser> YorumluoUsers { get; set; }
        public DbSet <ProfileImage> ProfileImages { get; set; }
        public DbSet <UserLikes> UserLikes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLikes>()
                 .HasKey(bc => new { bc.YorumId, bc.UserId });

            modelBuilder.Entity<UserLikes>()
                .HasOne(x => x.LikeUsers)
                .WithMany(s => s.LikedYorum)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserLikes>()
                .HasOne<Yorum>(sc => sc.LikedYorums)
                .WithMany(s => s.LikedUser)
                .HasForeignKey(sc => sc.YorumId);


        }
    }
}
