using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PublicPolicyAggregate.Values;
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
    private const string STRATEGICLINE_PUBLICPOLICY_BRIDGES_TABLE_NAME = "strategicline_publicpolicy_bridges";
    private const string STRATEGICLINE_MACROPROGRAM_BRIDGES_TABLE_NAME = "strategicline_macroprogram_bridges";
    private const string ACTIONS_TABLE_NAME = "strategicline_strategicactions";
    private const string SPECIFICOBJECTIVES_TABLE_NAME = "strategicline_specificobjectives";

    public void Configure(EntityTypeBuilder<StrategicLine> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.AxeId)
            .ValueGeneratedNever()
            .HasConversion(new NullableStrategicAxeIdConverter());

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Objective)
            .HasMaxLength(1024);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasOne(entity => entity.Axe).WithMany().HasForeignKey(entity => entity.AxeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinatorId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(entity => new { entity.Index, entity.AxeId }).IsUnique();

        builder
            .OwnsMany(entity => entity.StrategicActions, Configure)
            .Navigation(entity => entity.StrategicActions)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("strategicActions");

        builder
            .OwnsMany(entity => entity.SpecificObjectives, Configure)
            .Navigation(entity => entity.SpecificObjectives)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("specificObjectives");

        builder
            .OwnsMany(entity => entity.OrganizationBridges, Configure)
            .Navigation(entity => entity.OrganizationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("organizationBridges");

        builder
            .OwnsMany(entity => entity.PublicPolicyBridges, Configure)
            .Navigation(entity => entity.PublicPolicyBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("publicPolicyBridges");

        builder
            .OwnsMany(entity => entity.MacroprogramBridges, Configure)
            .Navigation(entity => entity.MacroprogramBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("macroprogramBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineOrganizationBridge> builder)
    {
        builder.ToTable(STRATEGICLINE_ORGANIZATION_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLinePublicPolicyBridge> builder)
    {
        builder.ToTable(STRATEGICLINE_PUBLICPOLICY_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PublicPolicyId(value));
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineMacroprogramBridge> builder)
    {
        builder.ToTable(STRATEGICLINE_MACROPROGRAM_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MacroprogramId(value));
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineSpecificObjective> builder)
    {
        builder.ToTable(SPECIFICOBJECTIVES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicLineId });

        builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineSpecificObjectiveId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.Content)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicLineAction> builder)
    {
        builder.ToTable(ACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicLineId });

        builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineActionId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);
    }
}
