using EFCoreSpeedTest.Business.Logic;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

namespace EFCoreSpeedTest.Api.Services;

public class UserAccountService : IUserAccountService
{
    private readonly UserAccountLogic _userAccountLogic;

    public UserAccountService(UserAccountLogic userAccountLogic)
    {
        _userAccountLogic = userAccountLogic;
    }
    
    public async Task Add(
        UserAccountAddArguments arguments,
        CancellationToken cancellationToken)
    {
        await _userAccountLogic.Add(arguments.Items, cancellationToken);
    }
    
    public async Task<UserAccountGetResponse> Get(UserAccountGetArguments arguments)
    {
        var userAccounts = await _userAccountLogic.Get(arguments.Ids);
        var response = new UserAccountGetResponse(userAccounts);
        
        return response;
    }
}