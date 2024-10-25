using EFCoreSpeedTest.Storage.Configurations.Base;
using EFCoreSpeedTest.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSpeedTest.Storage.Configurations;

public class UserAccountConfiguration : EntityConfiguration<UserAccount>
{
    public override void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Username).IsRequired();
        builder.HasIndex(p => p.Username).HasMethod("GIN");
        
        builder.Property(p => p.Email).IsRequired();
        builder.HasIndex(p => p.Email).IsUnique();
        
        builder.Property(p => p.IpAddress)
            .IsRequired()
            .HasColumnType("inet");
        
        builder.HasIndex(p => p.IpAddress);
    }
}