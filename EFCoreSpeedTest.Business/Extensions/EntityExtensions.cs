using EFCoreSpeedTest.Business.Exceptions;
using EFCoreSpeedTest.Common;
using EFCoreSpeedTest.Storage.Entities;

namespace EFCoreSpeedTest.Business.Extensions;

public static class EntityExtensions
{
    public static T EntityOrNotFound<T>(this T entity, Guid id) 
        where T : Entity
    {
        if (entity == null)
            throw new EntityNotFoundException(typeof(T), id);
        
        return entity;
    }
    
    public static IEnumerable<T> EntitiesOrNotFound<T>(this IEnumerable<T> entities, IEnumerable<Guid> ids) 
        where T : Entity
    {
        if (entities.IsNullOrEmpty())
            throw new EntityNotFoundException(typeof(T), ids);
        
        return entities;
    }
}