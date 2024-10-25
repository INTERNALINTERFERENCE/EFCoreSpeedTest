using EFCoreSpeedTest.Business.Exceptions;
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
    
    public static IEnumerable<T> EntityOrNotFound<T>(this IEnumerable<T> entity, IEnumerable<Guid> ids) 
        where T : Entity
    {
        if (entity == null)
            throw new EntityNotFoundException(typeof(T), ids);
        
        return entity;
    }
}