using EFCoreSpeedTest.Api.Services;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

namespace EFCoreSpeedTest.Api.Queries;

public class UserAccountQuery
{
    public Task<UserAccountGetResponse> GetUserAccounts(
        [Service] IUserAccountService service, 
        UserAccountGetArguments arguments) => 
        service.Get(arguments);
}