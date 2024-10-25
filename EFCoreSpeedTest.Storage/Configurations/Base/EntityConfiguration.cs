using EFCoreSpeedTest.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreSpeedTest.Storage.Configurations.Base;

public class EntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedNever().IsRequired();
        builder.Property(p => p.CreatedAt).ValueGeneratedNever().IsRequired();
    }
}