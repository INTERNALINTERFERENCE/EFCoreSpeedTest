using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Extensions;
using EFCoreSpeedTest.Storage.Entities;

namespace EFCoreSpeedTest.Business.Logic;

public class UserAccountLogic : EntityLogic
{
    public UserAccountLogic(SpeedDbContext dbContextFactory) : base(dbContextFactory)
    {
    }
    
    public async Task<IEnumerable<UserAccountDto>> Get(ICollection<Guid> ids)
    {
        var entities = SpeedDbContext
            .Set<UserAccount>()
            .Where(userAccount => ids.Contains(userAccount.Id));
        
        var userAccounts = entities.Select(entity => entity.ToDto());

        return userAccounts;
    }

    public async Task Add(IEnumerable<UserAccountDto> userAccounts, CancellationToken cancellationToken)
    {
        var userAccountsEntities = userAccounts.Select(dto => dto.ToEntity());
        
        await SpeedDbContext
            .Set<UserAccount>()
            .BulkInsertAsync(userAccountsEntities, cancellationToken);
    }
}