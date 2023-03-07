using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst
{
    public class SomeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public SomeContext()
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        public SomeContext(DbContextOptions<SomeContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost; port=5432; database=test; username=postgres; password=2800");
        }
    }
}
