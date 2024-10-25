using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreSpeedTest.Storage;

public class SpeedDbContextFactory : ISpeedDbContextFactory
{
    private readonly ILogger<SpeedDbContextFactory> _logger;
    private readonly SpeedDbContextConfiguration _speedDbContextConfiguration;

    public SpeedDbContextFactory(
        ILogger<SpeedDbContextFactory> logger,
        SpeedDbContextConfiguration speedDbContextConfiguration)
    {
        _logger = logger;
        _speedDbContextConfiguration = speedDbContextConfiguration;
    }
    
    public SpeedDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<SpeedDbContext>()
            .UseNpgsql(_speedDbContextConfiguration.ConnectionString);

        if (_speedDbContextConfiguration.LoggingEnabled)
        {
            if(_speedDbContextConfiguration.SensitiveDataLoggingEnabled)
                optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.LogTo(action => _logger.LogDebug("{}", action), [DbLoggerCategory.Database.Name]);
        }

        return new(optionsBuilder.Options);
    }
}