using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PtmkTest.Data.Users;

namespace PtmkTest;

public class DatabaseContext: DbContext
{
    public DbSet<UserDbModel> Users { get; set; }

    public DatabaseContext(DbContextOptions options): base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSnakeCaseNamingConvention();
        // optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
}

public class Factory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres")
            .Options;

        return new DatabaseContext(options);
    }

    public static DatabaseContext CreateDbContext()
    {
        var factory = new Factory();
        return factory.CreateDbContext(Array.Empty<string>());
    }
}

