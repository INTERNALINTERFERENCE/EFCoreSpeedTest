using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

public class UserAccountAddArguments : EntityItems<UserAccountDto>
{
    public UserAccountAddArguments() { }
    public UserAccountAddArguments(UserAccountDto item) : base(item) { }
    public UserAccountAddArguments(IEnumerable<UserAccountDto> items) : base(items) { }
}