using NodaTime;

namespace EFCoreSpeedTest.Storage.Entities;

public class Entity
{
    public required Guid Id { get; set; }
    
    public LocalDateTime CreatedAt { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = LocalDateTime.FromDateTime(DateTime.UtcNow);
    }
}