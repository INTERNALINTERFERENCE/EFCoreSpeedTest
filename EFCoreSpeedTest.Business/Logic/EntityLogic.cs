using EFCoreSpeedTest.Business.Extensions;
using EFCoreSpeedTest.Storage;

namespace EFCoreSpeedTest.Business.Logic;

public class EntityLogic
{
    protected readonly SpeedDbContext SpeedDbContext;

    protected EntityLogic(SpeedDbContext dbContext)
    {
        SpeedDbContext = dbContext;
    }
}