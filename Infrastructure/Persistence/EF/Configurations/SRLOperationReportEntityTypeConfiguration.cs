using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class SRLOperationReportEntityTypeConfiguration : IEntityTypeConfiguration<SRLOperationReport>
{
    private const string TABLE_NAME = "srloperationreports";
    private const string ACCOUNTING_ENTRY_TABLE_NAME = "srloperationreport_accountingentries";

    public void Configure(EntityTypeBuilder<SRLOperationReport> builder)
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

        builder
            .OwnsMany(entity => entity.AccountingEntries, Configure)
            .Navigation(entity => entity.AccountingEntries)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("accountingEntries");

        builder.HasIndex(entity => new { entity.OwnerId, entity.Period }).IsUnique();
    }

    private void Configure(OwnedNavigationBuilder<SRLOperationReport, OperationReportAccountingEntry> builder)
    {
        builder.ToTable(ACCOUNTING_ENTRY_TABLE_NAME);

        builder.Property(entity => entity.ReportId)
            .HasConversion(id => id.Value, value => new OperationReportId(value));

        builder.HasKey(entity => new { entity.Kind, entity.ReportId, entity.Currency });

        builder.WithOwner().HasForeignKey(entity => entity.ReportId);
    }
}
