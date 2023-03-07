using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableSample
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost; port=5432; database=ienumerabledb; username=postgres; password=2800");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User { Id = 1, Name = "Abdu"},
                new User { Id = 2, Name = "Abduvali" },
                new User { Id = 3, Name = "Abdugani" },
                new User { Id = 4, Name = "Abdullo" },
                new User { Id = 5, Name = "Abdulatif" },
                new User { Id = 6, Name = "Abdurauf" },
                new User { Id = 7, Name = "Abdujalil" },
                new User { Id = 8, Name = "Abdushukur" },
                new User { Id = 9, Name = "Abduumed" },
                new User { Id = 10, Name = "Abduahad" });
        }
    }
}
