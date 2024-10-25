using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

namespace EFCoreSpeedTest.Api.Services;

public class UserAccountService : BaseService, IUserAccountService
{
    public UserAccountService(ISpeedDbContextFactory dbContextFactory) : base(dbContextFactory)
    {
    }

    public async Task Add(
        UserAccountAddArguments arguments,
        CancellationToken cancellationToken)
    {
        await UserAccountLogic.Add(arguments.Items, cancellationToken);
    }
    
    public async Task<UserAccountGetResponse> Get(
        UserAccountGetArguments arguments, 
        CancellationToken cancellationToken)
    {
        var userAccounts = await UserAccountLogic.Get(arguments.Ids, cancellationToken);
        var response = new UserAccountGetResponse(userAccounts);
        
        return response;
    }
}