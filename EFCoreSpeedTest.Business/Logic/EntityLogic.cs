using EFCoreSpeedTest.Business.Extensions;
using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Entities;

namespace EFCoreSpeedTest.Business.Logic;

public class EntityLogic
{
    protected readonly ISpeedDbContextFactory DbContextFactory;

    public EntityLogic(ISpeedDbContextFactory dbContextFactory)
    {
        DbContextFactory = dbContextFactory;
    }
}