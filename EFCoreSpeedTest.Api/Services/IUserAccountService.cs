using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

namespace EFCoreSpeedTest.Api.Services;

public interface IUserAccountService
{
    Task Add(UserAccountAddArguments arguments, CancellationToken cancellationToken);
    
    Task<UserAccountGetResponse> Get(UserAccountGetArguments arguments, CancellationToken cancellationToken);
}