using NodaTime;

namespace EFCoreSpeedTest.Storage.Extensions;

public static class DateTimeExtensions
{
    public static DateTimeZone GetTimeZone(this SystemClock systemClock)
    {
        var instance = systemClock.GetCurrentInstant();
        var zone = DateTimeZoneProviders.Bcl.GetSystemDefault();
        
        return instance.InZone(zone).Zone;
    }
}