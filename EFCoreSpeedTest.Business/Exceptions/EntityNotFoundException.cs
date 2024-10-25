namespace EFCoreSpeedTest.Business.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type entityType, Guid id)
        : base($"Entity not found. Type: {entityType.Name}, id: {id}." )
    {
    }
    
    public EntityNotFoundException(Type entityType, IEnumerable<Guid> ids) 
        : base($"Entity not found. Type: {entityType.Name}, ids: [{string.Join(',', ids)}].")
    {
    }
}
