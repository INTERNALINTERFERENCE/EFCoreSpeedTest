using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;

namespace EFCoreSpeedTest.Storage.Abstractions.UserAccount.Extensions;

public static class Dto
{
    public static Entities.UserAccount ToEntity(this UserAccountDto userAccount)
    {
        return new Entities.UserAccount
        {
            Id = userAccount.Id,
            Email = userAccount.Email,
            IpAddress = userAccount.IpAddress,
            Username = userAccount.Username
        };
    }

    public static UserAccountDto ToDto(this Entities.UserAccount userAccount)
    {
        return new UserAccountDto
        {
            Id = userAccount.Id,
            Email = userAccount.Email,
            IpAddress = userAccount.IpAddress,
            Username = userAccount.Username
        };
    }
}