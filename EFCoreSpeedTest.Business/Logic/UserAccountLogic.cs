﻿using EFCoreSpeedTest.Storage;
using EFCoreSpeedTest.Storage.Abstractions.UserAccount.Dto;
using EFCoreSpeedTest.Storage.Entities;

namespace EFCoreSpeedTest.Business.Logic;

public class UserAccountLogic : EntityLogic<UserAccount>
{
    public UserAccountLogic(SpeedDbContext dbContextFactory) : base(dbContextFactory)
    {
    }

    public async Task<IEnumerable<UserAccountDto>> Get(ICollection<Guid> ids)
    {
        var entities = SpeedDbContext.Set<UserAccount>().Where(userAccount => ids.Contains(userAccount.Id));

        var userAccounts = entities.Select(entity => new UserAccountDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            IpAddress = entity.IpAddress
        });

        return userAccounts;
    }

    public async Task Add(IEnumerable<UserAccountDto> userAccounts, CancellationToken cancellationToken)
    {
        var userAccountsEntities = userAccounts.Select(dto => new UserAccount
        {
            Id = dto.Id,
            Username = dto.Username,
            Email = dto.Email,
            IpAddress = dto.IpAddress,
        });
        
        await SpeedDbContext.Set<UserAccount>().BulkInsertAsync(userAccountsEntities, cancellationToken);
    }
}