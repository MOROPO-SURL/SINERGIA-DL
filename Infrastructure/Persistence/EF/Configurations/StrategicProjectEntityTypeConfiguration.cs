using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectKindAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Entities;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class StrategicProjectEntityTypeConfiguration : IEntityTypeConfiguration<StrategicProject>
{
    private const string ROOT_TABLE_NAME = "strategicprojects";

    private const string SPECIFICOBJETIVEPROJECTS_TABLE_NAME = "strategicproject_specificobjetives";
    private const string STRATEGICPROJECT_MACROPROGRAM_BRIDGES_TABLE_NAME = "strategicproject_macroprogram_bridges";
    private const string INDICATORS_TABLE_NAME = "strategicproject_indicators";
    private const string INDICATOR_MILESTONES_TABLE_NAME = "strategicproject_indicator_milestones";
    private const string INDICATOR_CHANGES_TABLE_NAME = "strategicproject_indicator_changes";

    public void Configure(EntityTypeBuilder<StrategicProject> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(entity => entity.KindId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectKindId(value));

        builder.Property(entity => entity.ProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Objective)
            .HasMaxLength(1024);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProgramId }).IsUnique();

        builder.HasOne(entity => entity.Kind).WithMany().HasForeignKey(entity => entity.KindId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Program).WithMany().HasForeignKey(entity => entity.ProgramId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.SpecificObjectives, Configure)
            .Navigation(entity => entity.SpecificObjectives)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("specificObjectives");

        builder
            .OwnsMany(entity => entity.Indicators, Configure)
            .Navigation(entity => entity.Indicators)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("indicators");

        builder
            .OwnsMany(entity => entity.MacroprogramBridges, Configure)
            .Navigation(entity => entity.MacroprogramBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("macroprogramBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProject, StrategicProjectMacroprogramBridge> builder)
    {
        builder.ToTable(STRATEGICPROJECT_MACROPROGRAM_BRIDGES_TABLE_NAME);

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MacroprogramId(value));

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProject, ProjectSpecificObjective> builder)
    {
        builder.ToTable(SPECIFICOBJETIVEPROJECTS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ProjectId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProjectId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectSpecificObjectiveId(value));

        builder.Property(entity => entity.ProjectId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(entity => entity.Content)
            .HasMaxLength(1024);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ProjectId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProject, ProjectIndicator> builder)
    {
        builder.ToTable(INDICATORS_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectIndicatorId(value));

        builder.Property(entity => entity.ProjectId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.HasKey(entity => new { entity.Id, entity.ProjectId});

        builder.WithOwner().HasForeignKey(entity => new { entity.ProjectId});

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProjectId}).IsUnique();

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

    private static void Configure(OwnedNavigationBuilder<ProjectIndicator, ProjectIndicatorMilestone> builder)
    {
        builder.ToTable(INDICATOR_MILESTONES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectIndicatorMilestoneId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectIndicatorId(value));

        builder.Property(entity => entity.ProjectId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(entity => entity.Description)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ProjectId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ProjectId });

        builder.HasIndex(entity => new { entity.Id, entity.IndicatorId, entity.ProjectId, entity.At }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<ProjectIndicator, ProjectIndicatorChange> builder)
    {
        builder.ToTable(INDICATOR_CHANGES_TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectIndicatorChangeId(value));

        builder.Property(entity => entity.IndicatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProjectIndicatorId(value));

        builder.Property(entity => entity.ProjectId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.Property(entity => entity.Context)
            .HasMaxLength(512);

        builder.HasKey(entity => new { entity.Id, entity.IndicatorId, entity.ProjectId });

        builder.WithOwner().HasForeignKey(entity => new { entity.IndicatorId, entity.ProjectId });
    }
}
