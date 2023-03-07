using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreCodeFirst
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<SomeContext>
    {
        public SomeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SomeContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
            return new SomeContext(optionsBuilder.Options);
        }
    }
}
