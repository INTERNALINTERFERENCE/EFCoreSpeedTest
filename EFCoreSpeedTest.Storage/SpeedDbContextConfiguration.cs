namespace EFCoreSpeedTest.Storage;

public class SpeedDbContextConfiguration
{
    public required string ConnectionString { get; set; }
    
    public required bool LoggingEnabled { get; set; }
    
    public required bool SensitiveDataLoggingEnabled { get; set; }
}