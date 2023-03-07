using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EFCoreDatabaseFirst;

public partial class TestContext : DbContext
{
    readonly StreamWriter logStream = new StreamWriter("myLog.txt", true);
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("host=localhost; port=5432; database=test; username=postgres; password=2800;");
        optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name /*RelationalEventId.CommandExecuted*/});
    }

    public override void Dispose()
    {
        base.Dispose();
        logStream.Dispose();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
