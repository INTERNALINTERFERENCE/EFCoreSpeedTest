using Newtonsoft.Json;

namespace EFCoreSpeedTest.Storage.Abstractions;

public class EntityItems<TEntity>
{
    public EntityItems()
    {
    }

    public EntityItems( TEntity item )
    {
        Items = [item];
    }

    public EntityItems( IEnumerable<TEntity> items )
    {
        Items = new(items);
    }

    [JsonProperty(PropertyName = "items")] 
    public List<TEntity> Items { get; set; } = [];
}