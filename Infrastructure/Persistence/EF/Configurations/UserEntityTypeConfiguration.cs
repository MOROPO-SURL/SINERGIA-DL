using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate;
using System.Security.Cryptography;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    private const string TABLE_NAME = "users";

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.UserAggregate.Values.UserId(value))
            .HasMaxLength(64);

        builder.Property(entity => entity.Password)
            .HasMaxLength(128);

        builder.Property(entity => entity.Name)
            .HasMaxLength(64);

        builder.Property(entity => entity.LastName)
            .HasMaxLength(128);

        builder.Property(bridge => bridge.Signature)
            .HasMaxLength(HMACSHA512.HashSizeInBytes * 2);

        builder.HasOne(entity => entity.Image).WithOne().HasForeignKey<User>(entity => entity.ImageId).OnDelete(DeleteBehavior.Cascade);
    }
}
