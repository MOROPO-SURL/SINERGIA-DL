using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OperationReportAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class PDLOperationReportEntityTypeConfiguration : IEntityTypeConfiguration<PDLOperationReport>
{
    private const string TABLE_NAME = "pdloperationreports";
    private const string DOCUMENT_BRIDGE_TABLE_NAME = "pdloperationreport_document_bridges";

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

        builder
            .OwnsMany(entity => entity.DocumentBridges, Configure)
            .Navigation(entity => entity.DocumentBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("documentBridges");

        builder.HasIndex(entity => new { entity.OwnerId, entity.Period }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<PDLOperationReport, OperationReportDocumentBridge> builder)
    {
        builder.ToTable(DOCUMENT_BRIDGE_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OperationReportId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new DocumentId(value));

        builder.HasKey(entity => new { entity.MainId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => entity.MainId);

        builder.HasOne(entity => entity.Linked).WithOne().HasForeignKey<OperationReportDocumentBridge>(entity => entity.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }
}