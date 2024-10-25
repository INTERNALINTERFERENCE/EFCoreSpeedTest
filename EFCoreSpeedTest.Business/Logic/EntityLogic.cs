using EFCoreSpeedTest.Business.Extensions;
using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Entities;

namespace EFCoreSpeedTest.Business.Logic;

public class EntityLogic<TEntity> where TEntity : Entity
{
    protected readonly SpeedDbContext SpeedDbContext;

    protected EntityLogic(SpeedDbContext dbContext)
    {
        SpeedDbContext = dbContext;
    }
}