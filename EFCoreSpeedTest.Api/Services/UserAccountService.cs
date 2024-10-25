using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

namespace EFCoreSpeedTest.Api.Services;

public class UserAccountService : BaseService, IUserAccountService
{
    public UserAccountService(SpeedDbContext dbContext) : base(dbContext)
    {
    }

    public async Task Add(
        UserAccountAddArguments arguments,
        CancellationToken cancellationToken)
    {
        await UserAccountLogic.Add(arguments.Items, cancellationToken);
    }
    
    public async Task<UserAccountGetResponse> Get(UserAccountGetArguments arguments)
    {
        var userAccounts = await UserAccountLogic.Get(arguments.Ids);
        var response = new UserAccountGetResponse(userAccounts);
        
        return response;
    }
}