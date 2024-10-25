using EFCoreSpeedTest.Business.Logic;
using EFCoreSpeedTest.Storage;

namespace EFCoreSpeedTest.Api.Services;

public abstract class BaseService
{
    protected UserAccountLogic UserAccountLogic;

    protected BaseService(ISpeedDbContextFactory dbContextFactory)
    {
        UserAccountLogic = new UserAccountLogic(dbContextFactory);
    }
}