using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Commands;

public class UserAccountGetArguments : EntityIds<Guid>
{
    public UserAccountGetArguments() { }
    public UserAccountGetArguments(Guid item) : base(item) { }
    public UserAccountGetArguments(IEnumerable<Guid> items) : base(items) { }
}