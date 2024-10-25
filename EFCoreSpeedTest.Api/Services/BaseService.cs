using EFCoreSpeedTest.Business.Logic;
using EFCoreSpeedTest.Storage;

namespace EFCoreSpeedTest.Api.Services;

public abstract class BaseService
{
    protected readonly UserAccountLogic UserAccountLogic;

    protected BaseService(SpeedDbContext dbContext)
    {
        UserAccountLogic = new UserAccountLogic(dbContext);
    }
}