using NodaTime;

namespace EFCoreSpeedTest.Storage.Entities;

public class Entity
{
    public required Guid Id { get; set; }
    
    public ZonedDateTime CreatedAt { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
    }
}