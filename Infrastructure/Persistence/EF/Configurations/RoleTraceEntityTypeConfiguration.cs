using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.RoleAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.TraceAggregate;
using System.Security.Cryptography;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class RoleTraceEntityTypeConfiguration : IEntityTypeConfiguration<RoleTrace>
{
    private const string TABLE_NAME = "role_traces";

    public void Configure(EntityTypeBuilder<RoleTrace> builder)
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
            .HasConversion(new NullableTargetIdConverter());

        builder.Property(entity => entity.Author)
            .HasMaxLength(64);

        builder.Property(bridge => bridge.Signature)
            .HasMaxLength(HMACSHA512.HashSizeInBytes * 2);

        builder.HasOne(entity => entity.Target).WithMany().HasForeignKey(entity => entity.TargetId).OnDelete(DeleteBehavior.SetNull);
    }

    public sealed class NullableTargetIdConverter : ValueConverter<RoleId?, Guid?>
    {
        public NullableTargetIdConverter()
            : base(
                id => id == null ? null : id.Value.Value,
                value => value == null ? null : new RoleId(value.Value))
        {
        }
    }
}