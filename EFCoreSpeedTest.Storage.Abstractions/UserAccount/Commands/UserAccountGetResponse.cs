using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

public class UserAccountGetResponse : EntityItems<UserAccountDto>
{
    public UserAccountGetResponse() { }
    public UserAccountGetResponse(UserAccountDto item) : base(item) { }
    public UserAccountGetResponse(IEnumerable<UserAccountDto> items) : base(items) { }
}