using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class PDLOperationReportEntityTypeConfiguration : IEntityTypeConfiguration<PDLOperationReport>
{
    private const string TABLE_NAME = "pdloperationreports";

    public void Configure(EntityTypeBuilder<PDLOperationReport> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new OperationReportId(value));

        builder.Property(entity => entity.OwnerId)
            .HasConversion(id => id.Value, value => new Domain.Aggretates.DevelopmentActorProfileAggregate.Values.DevelopmentActorProfileId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(1024);

        builder.HasKey(entity => entity.Id);

        builder.HasOne(entity => entity.Owner).WithMany().HasForeignKey(entity => entity.OwnerId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(entity => new { entity.OwnerId, entity.Period }).IsUnique();
    }
}