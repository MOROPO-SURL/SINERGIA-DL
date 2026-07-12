using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicLineAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProgramAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicProjectAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class StrategicProgramEntityTypeConfiguration : IEntityTypeConfiguration<StrategicProgram>
{
    private const string ROOT_TABLE_NAME = "strategicprograms";

    private const string ACTIONS_TABLE_NAME = "strategicprogram_actions";
    private const string ACTION_INTERESTAREA_BRIDGES_TABLE_NAME = "strategicprogram_action_interestarea_bridges";
    private const string PROJECTIDEAS_TABLE_NAME = "strategicprogram_projectideas";
    private const string OBJETIVES_TABLE_NAME = "strategicprogram_objetives";
    private const string IMPACTS_TABLE_NAME = "strategicprogram_impacts";
    private const string IMPACTINDICATORS_TABLE_NAME = "strategicprogram_impactindicators";
    private const string OBJECTIVE_STRATEGICPROJECT_BRIDGES_TABLE_NAME = "strategicprogram_objective_strategicproject_bridges";
    private const string STRATEGICPROGRAM_ORGANIZATION_BRIDGES_TABLE_NAME = "strategicprogram_organization_bridges";
    private const string STRATEGICPROGRAM_MACROPROGRAM_BRIDGES_TABLE_NAME = "strategicprogram_macroprogram_bridges";

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
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PersonId(value));

        builder.HasOne(entity => entity.Line).WithMany().HasForeignKey(entity => entity.LineId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinatorId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.Objetives, Configure)
            .Navigation(entity => entity.Objetives)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("objetives");

        builder
            .OwnsMany(entity => entity.Actions, Configure)
            .Navigation(entity => entity.Actions)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("actions");

        builder
            .OwnsMany(entity => entity.ProjectIdeas, Configure)
            .Navigation(entity => entity.ProjectIdeas)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("projectIdeas");

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

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramObjective> builder)
    {
        builder.ToTable(OBJETIVES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramObjectiveId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder
            .OwnsMany(entity => entity.StrategicProjectBridges, Configure)
            .Navigation(entity => entity.StrategicProjectBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("strategicProjectBridges");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramObjective, ProgramObjectiveStrategicProjectBridge> builder)
    {
        builder.ToTable(OBJECTIVE_STRATEGICPROJECT_BRIDGES_TABLE_NAME);

        builder.HasKey(entity => new { entity.ProgramObjectiveId, entity.StrategicProgramId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramObjectiveId, entity.StrategicProgramId });

        builder.Property(entity => entity.ProgramObjectiveId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramObjectiveId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProjectId(value));

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramAction> builder)
    {
        builder.ToTable(ACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        //builder.Property(entity => entity.ParentId)
        //    .ValueGeneratedNever()
        //    .HasConversion(id => id!.Value.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        //builder.HasOne(entity => entity.Parent).WithMany().HasForeignKey(entity => entity.ParentId);

        builder
            .OwnsMany(entity => entity.InterestAreaBridges, Configure)
            .Navigation(entity => entity.InterestAreaBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("interestAreaBridges");
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

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramProjectIdea> builder)
    {
        builder.ToTable(PROJECTIDEAS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramProjectIdeaId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramImpact> builder)
    {
        builder.ToTable(IMPACTS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramImpactId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId }).IsUnique();

        builder
            .OwnsMany(entity => entity.ImpactIndicator, Configure)
            .Navigation(entity => entity.ImpactIndicator).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("impactIndicators");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramImpact, ImpactIndicator> builder)
    {
        builder.ToTable(IMPACTINDICATORS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ProgramImpactId, entity.StrategicProgramId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramImpactId, entity.StrategicProgramId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ImpactIndicatorId(value));

        builder.Property(entity => entity.ProgramImpactId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ProgramImpactId(value));

        builder.Property(entity => entity.StrategicProgramId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProgramImpactId, entity.StrategicProgramId }).IsUnique();

        builder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(DeleteBehavior.Restrict);
    }
}