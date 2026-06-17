using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Converters;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class StrategicLineEntitTypeConfiguration : IEntityTypeConfiguration<StrategicLine>
{
    private const string ROOT_TABLE_NAME = "strategiclines";

    private const string STRATEGICLINE_ORGANIZATION_BRIDGES_TABLE_NAME = "strategicline_organization_bridges";
    private const string ACTIONS_TABLE_NAME = "strategicline_strategicactions";

    public void Configure(EntityTypeBuilder<StrategicLine> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => new { entity.FirstId, entity.SecoundId });

        builder.Property(entity => entity.FirstId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.SecoundId)
            .ValueGeneratedNever()
            .HasConversion(new NullableStrategicAxeIdConverter());

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Objective)
            .HasMaxLength(1024);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasOne(entity => entity.StrategicAxe).WithMany().HasForeignKey(entity => entity.SecoundId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinadorId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.StrategicActions, Configure)
            .Navigation(entity => entity.StrategicActions).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("strategicActions");

        builder
            .OwnsMany(entity => entity.OrganizationBridges, Configure)
            .Navigation(entity => entity.OrganizationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("organizationBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineOrganizationBridge> builder)
    {
        builder.ToTable(STRATEGICLINE_ORGANIZATION_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.StrategicLineId, bridge.StrategicAxesId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => new { bridge.StrategicLineId, bridge.StrategicAxesId });

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(new NullableStrategicAxeIdConverter());

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineAction> builder)
    {
        builder.ToTable(ACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicLineId, entity.StrategicAxeId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicLineId, entity.StrategicAxeId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineActionId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxeId)
            .ValueGeneratedNever()
            .HasConversion(new NullableStrategicAxeIdConverter());

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);
    }
}
