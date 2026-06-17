using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.TraceAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;
using System.Security.Cryptography;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class StrategicLineTraceEntityTypeConfiguration : IEntityTypeConfiguration<StrategicLineTrace>
{
    private const string TABLE_NAME = "strategicline_traces";

    public void Configure(EntityTypeBuilder<StrategicLineTrace> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.TraceAggregate.Values.TraceId(value))
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(entity => entity.TargetPrimaryId)
            .IsRequired(false)
            .ValueGeneratedNever()
            .HasConversion(new NullableTargetPrimaryIdConverter());

        builder.Property(entity => entity.TargetSecoundaryId)
            .IsRequired(false)
            .ValueGeneratedNever()
            .HasConversion(new NullableStrategicAxeIdConverter());

        builder.Property(entity => entity.Author)
            .HasMaxLength(64);

        builder.Property(bridge => bridge.Signature)
            .HasMaxLength(HMACSHA512.HashSizeInBytes * 2);

        builder.HasOne(entity => entity.Target).WithMany().HasForeignKey(entity => new { entity.TargetPrimaryId, entity.TargetSecoundaryId }).OnDelete(DeleteBehavior.SetNull);
    }

    private sealed class NullableTargetPrimaryIdConverter : ValueConverter<StrategicLineId?, int?>
    {
        public NullableTargetPrimaryIdConverter()
            : base(
                id => id == null ? null : id.Value.Value,
                value => value == null ? null : new StrategicLineId(value.Value))
        {
        }
    }
}