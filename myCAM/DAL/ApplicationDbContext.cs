using System.Data.Entity;
using myCAM.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace myCAM.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Gallery> Galleries { get; set; }

        public static ApplicationDbContext Create()
        {
            var applicationDbContext = new ApplicationDbContext();
            return applicationDbContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gallery>()
                .HasRequired(g => g.ApplicationUser)
                .WithMany(au => au.Galleries)
                .HasForeignKey(gallery => gallery.ApplicationUserId);
            ////modelBuilder.Entity<IdentityUserLogin>().HasKey(login => login.)
        }


    }
}