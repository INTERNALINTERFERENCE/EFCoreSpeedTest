using Microsoft.EntityFrameworkCore;

namespace EFCoreSpeedTest.Storage;

public class SpeedDbContext : DbContext
{
    public SpeedDbContext(DbContextOptions<SpeedDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasPostgresExtension("pg_trgm");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeedDbContext).Assembly);
    }
}