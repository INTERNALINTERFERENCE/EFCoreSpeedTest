using Newtonsoft.Json;

namespace EFCoreSpeedTest.Storage.Abstractions;

public class EntityIds<TId>
{
    public EntityIds()
    {
    }

    public EntityIds(TId id)
    {
        Ids = [id];
    }

    public EntityIds(IEnumerable<TId> ids)
    {
        Ids = new(ids);
    }

    [JsonProperty(PropertyName = "ids")] 
    public HashSet<TId> Ids { get; set; } = [];
}