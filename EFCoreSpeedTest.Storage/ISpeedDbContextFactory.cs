using Microsoft.EntityFrameworkCore;

namespace EFCoreSpeedTest.Storage;

public interface ISpeedDbContextFactory : IDbContextFactory<SpeedDbContext>
{
}