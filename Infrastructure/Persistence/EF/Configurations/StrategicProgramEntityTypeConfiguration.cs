using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class StrategicProgramEntityTypeConfiguration : IEntityTypeConfiguration<StrategicProgram>
{
    private const string ROOT_TABLE_NAME = "strategicprograms";

    private const string SPECIFICOBJETIVES_TABLE_NAME = "strategicprogram_specificobjetives";
    private const string SPECIFICOBJECTIVE_STRATEGICPROJECT_BRIDGES_TABLE_NAME = "strategicprogram_specificobjective_strategicproject_bridges";
    private const string IMPACTS_TABLE_NAME = "strategicprogram_impacts";
    private const string STRATEGICPROGRAM_ORGANIZATION_BRIDGES_TABLE_NAME = "strategicprogram_organization_bridges";
    private const string STRATEGICPROGRAM_MACROPROGRAM_BRIDGES_TABLE_NAME = "strategicprogram_macroprogram_bridges";
    private const string ACTIONS_TABLE_NAME = "strategicprogram_actions";
    private const string ACTION_INDICATORS_TABLE_NAME = "strategicprogram_action_indicators";
    private const string ACTION_INDICATOR_MILESTONES_TABLE_NAME = "strategicprogram_action_indicator_milestones";
    private const string ACTION_INDICATOR_CHANGES_TABLE_NAME = "strategicprogram_action_indicator_changes";
    private const string ACTION_INTERESTAREA_BRIDGES_TABLE_NAME = "strategicprogram_action_interestarea_bridges";

    public void Configure(EntityTypeBuilder<StrategicProgram> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.LineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Objective)
            .HasMaxLength(1024);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.Property(entity => entity.CoordinatorId)
            .HasConversion(id => id.Value, value => new PersonId(value));

        builder.HasOne(entity => entity.Line).WithMany().HasForeignKey(entity => entity.LineId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinatorId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.SpecificObjectives, Configure)
            .Navigation(entity => entity.SpecificObjectives)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("specificObjectives");

        builder
            .OwnsMany(entity => entity.Actions, Configure)
            .Navigation(entity => entity.Actions)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("actions");

        builder
            .OwnsMany(entity => entity.Impacts, Configure)
            .Navigation(entity => entity.Impacts)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("impacts");

        builder
            .OwnsMany(entity => entity.MacroprogramBridges, Configure)
            .Navigation(entity => entity.MacroprogramBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("macroprogramBridges");

        builder
            .OwnsMany(entity => entity.OrganizationBridges, Configure)
            .Navigation(entity => entity.OrganizationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("organizationBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, StrategicProgramOrganizationBridge> builder)
    {
        builder.ToTable(STRATEGICPROGRAM_ORGANIZATION_BRIDGES_TABLE_NAME);

        builder.Property(entity => entity.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, StrategicProgramMacroprogramBridge> builder)
    {
        builder.ToTable(STRATEGICPROGRAM_MACROPROGRAM_BRIDGES_TABLE_NAME);

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MacroprogramId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramSpecificObjective> builder)
    {
        builder.ToTable(SPECIFICOBJETIVES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramSpecificObjectiveId(value));

        builder.Property(entity => entity.ProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Content)
            .HasMaxLength(1024);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ProgramId }).IsUnique();

        builder
            .OwnsMany(entity => entity.ProjectBridges, Configure)
            .Navigation(entity => entity.ProjectBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("projectBridges");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramSpecificObjective, ProgramSpecificObjectiveStrategicProjectBridge> builder)
    {
        builder.ToTable(SPECIFICOBJECTIVE_STRATEGICPROJECT_BRIDGES_TABLE_NAME);

        builder.HasKey(entity => new { entity.ProgramObjectiveId, entity.StrategicProgramId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramObjectiveId, entity.StrategicProgramId });

        builder.Property(entity => entity.ProgramObjectiveId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramSpecificObjectiveId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramImpact> builder)
    {
        builder.ToTable(IMPACTS_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramImpactId(value));

        builder.Property(entity => entity.ProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasKey(entity => new { entity.Id, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramId });

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProgramId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramAction> builder)
    {
        builder.ToTable(ACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.ProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder
            .OwnsMany(entity => entity.InterestAreaBridges, Configure)
            .Navigation(entity => entity.InterestAreaBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("interestAreaBridges");

        builder
            .OwnsMany(entity => entity.Indicators, Configure)
            .Navigation(entity => entity.Indicators)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("indicators");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramAction, ProgramActionInterestAreaBridge> builder)
    {
        builder.ToTable(ACTION_INTERESTAREA_BRIDGES_TABLE_NAME);

        builder.HasKey(entity => new { entity.ProgramActionId, entity.StrategicProgramId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramActionId, entity.StrategicProgramId });

        builder.Property(entity => entity.ProgramActionId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new InterestAreaId(value));

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }

    private static void Configure(OwnedNavigationBuilder<ProgramAction, ProgramActionIndicator> builder)
    {
        builder.ToTable(ACTION_INDICATORS_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.ProgramId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.HasKey(entity => new { entity.Id, entity.ActionId, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ActionId, entity.ProgramId });

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ActionId, entity.ProgramId }).IsUnique();

        builder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.Milestones, Configure)
            .Navigation(entity => entity.Milestones)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("milestones");

        builder
            .OwnsMany(entity => entity.Changes, Configure)
            .Navigation(entity => entity.Changes)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("changes");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramActionIndicator, ProgramActionIndicatorMilestone> builder)
    {
        builder.ToTable(ACTION_INDICATOR_MILESTONES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionIndicatorMilestoneId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.ProgramId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ActionId, entity.ProgramId });

        builder.HasIndex(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ProgramId, entity.At }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<ProgramActionIndicator, ProgramActionIndicatorChange> builder)
    {
        builder.ToTable(ACTION_INDICATOR_CHANGES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionIndicatorChangeId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.ProgramId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Context)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ActionId, entity.ProgramId });
    }
}