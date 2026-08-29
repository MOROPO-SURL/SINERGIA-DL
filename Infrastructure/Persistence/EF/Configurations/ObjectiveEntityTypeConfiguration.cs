using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicProgramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class ObjectiveEntityTypeConfiguration : IEntityTypeConfiguration<Objective>
{
    private const string OBJECTIVES_TABLE_NAME = "objectives";
    private const string CHALLANGES_TABLE_NAME = "objective_challanges";
    private const string ACTIONS_TABLE_NAME = "objective_actions";
    private const string ACTION_INDICATORS_TABLE_NAME = "objective_action_indicators";
    private const string ACTION_INDICATOR_MILESTONES_TABLE_NAME = "objective_action_indicator_milestones";
    private const string ACTION_INDICATOR_CHANGES_TABLE_NAME = "objective_action_indicator_changes";
    private const string PROJECTIONS_TABLE_NAME = "objective_projections";

    public void Configure(EntityTypeBuilder<Objective> builder)
    {
        builder.ToTable(OBJECTIVES_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => entity.Index).IsUnique();


        builder
            .OwnsMany(entity => entity.Projections, Configure)
            .Navigation(entity => entity.Projections)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("projections");

        builder
            .OwnsMany(entity => entity.Challenges, Configure)
            .Navigation(entity => entity.Challenges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("challenges");

        builder
            .OwnsMany(entity => entity.Actions, Configure)
            .Navigation(entity => entity.Actions)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("actions");
    }

    private static void Configure(OwnedNavigationBuilder<Objective, ObjectiveChallenge> builder)
    {
        builder.ToTable(CHALLANGES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => entity.ObjectiveId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveChallengeId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ObjectiveId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<Objective, ObjectiveAction> builder)
    {
        builder.ToTable(ACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => entity.ObjectiveId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionId(value));

        builder.Property(entity => entity.ObjectiveId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ObjectiveId }).IsUnique();

        builder
            .OwnsMany(entity => entity.Indicators, Configure)
            .Navigation(entity => entity.Indicators)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("indicators");
    }

    private static void Configure(OwnedNavigationBuilder<ObjectiveAction, ObjectiveActionIndicator> builder)
    {
        builder.ToTable(ACTION_INDICATORS_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveActionId(value));

        builder.Property(entity => entity.ObjectiveId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.HasKey(entity => new { entity.Id, entity.ActionId, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ActionId, entity.ObjectiveId });

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ActionId, entity.ObjectiveId }).IsUnique();

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

    private static void Configure(OwnedNavigationBuilder<ObjectiveActionIndicator, ObjectiveActionIndicatorMilestone> builder)
    {
        builder.ToTable(ACTION_INDICATOR_MILESTONES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionIndicatorMilestoneId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveActionId(value));

        builder.Property(entity => entity.ObjectiveId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ActionId, entity.ObjectiveId });

        builder.HasIndex(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ObjectiveId, entity.At }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<ObjectiveActionIndicator, ObjectiveActionIndicatorChange> builder)
    {
        builder.ToTable(ACTION_INDICATOR_CHANGES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionIndicatorChangeId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveActionIndicatorId(value));

        builder.Property(entity => entity.ActionId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveActionId(value));

        builder.Property(entity => entity.ObjectiveId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ObjectiveId(value));

        builder.Property(entity => entity.Context)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ActionId, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ActionId, entity.ObjectiveId });
    }

    private static void Configure(OwnedNavigationBuilder<Objective, ObjectiveProjection> builder)
    {
        builder.ToTable(PROJECTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ObjectiveId });

        builder.WithOwner().HasForeignKey(entity => entity.ObjectiveId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ObjectiveProjectionId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ObjectiveId }).IsUnique();
    }
}
