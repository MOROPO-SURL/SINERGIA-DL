using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate.Values;
using System.Security.Cryptography;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class UserTraceEntityTypeConfiguration : IEntityTypeConfiguration<UserTrace>
{
    private const string TABLE_NAME = "user_traces";

    public void Configure(EntityTypeBuilder<UserTrace> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.TraceAggregate.Values.TraceId(value))
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(entity => entity.TargetId)
            .IsRequired(false)
            .ValueGeneratedNever()
            .HasConversion(id => id == null ? null : id.Value.Value, value => value == null ? null : new UserId(value));

        builder.Property(entity => entity.Author)
            .HasMaxLength(64);

        builder.Property(bridge => bridge.Signature)
            .HasMaxLength(HMACSHA512.HashSizeInBytes * 2);

        builder.HasOne(entity => entity.Target).WithMany().HasForeignKey(entity => entity.TargetId).OnDelete(DeleteBehavior.SetNull);
    }
}