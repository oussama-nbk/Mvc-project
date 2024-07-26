using CourceMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CourceMvc.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Romantic", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Sport", DisplayOrder = 3 }
                );
        }
    }
}
