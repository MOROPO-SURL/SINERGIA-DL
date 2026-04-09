using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.PersonAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.StrategicAxesAggregate.Bridges;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.OrganizationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class StrategicAxesEntityTypeConfiguration : IEntityTypeConfiguration<StrategicAxes>
{
    private const string STRATEGICAXES_TABLE_NAME = "strategicaxes";

    private const string STRATEGICLINES_TABLE_NAME = "strategicaxe_strategiclines";
    private const string STRATEGICLINE_ORGANIZATION_BRIDGES_TABLE_NAME = "strategicaxe_strategicline_organization_bridges";
    private const string STRATEGICACTIONS_TABLE_NAME = "strategicaxe_strategicactions";
    private const string STRATEGICPROGRAMS_TABLE_NAME = "strategicaxe_strategicprograms";
    private const string STRATEGICPROGRAM_ORGANIZATION_BRIDGES_TABLE_NAME = "strategicaxe_strategicprogram_organization_bridges";

    private const string PROGRAMACTIONS_TABLE_NAME = "strategicaxe_programactions";
    private const string PROGRAMACTION_INTERESTAREA_BRIDGES_TABLE_NAME = "strategicaxe_programaction_interestarea_bridges";
    private const string PROGRAMIDEAPROJECTS_TABLE_NAME = "strategicaxe_programideaprojects";
    private const string PROGRAMEXECUTIONPROJECTS_TABLE_NAME = "strategicaxe_programexecutionprojects";
    //private const string PROGRAMEXECUTIONPROJECT_PROGRAMOBJECTIVE_BRIDGES_TABLE_NAME = "strategicaxe_programexecutionproyect_programobjetive_bridges";
    private const string PROGRAMOBJETIVES_TABLE_NAME = "strategicaxe_programobjetives";
    private const string PROGRAMIMPACTS_TABLE_NAME = "strategicaxe_programimpacts";

    private const string IMPACTINDICATORS_TABLE_NAME = "impactindicators";

    public void Configure(EntityTypeBuilder<StrategicAxes> builder)
    {
        builder.ToTable(STRATEGICAXES_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => entity.Index).IsUnique();


        builder
            .OwnsMany(entity => entity.Lines, Configure)
            .Navigation(entity => entity.Lines).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("lines");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicAxes, StrategicLine> builder)
    {
        builder.ToTable(STRATEGICLINES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicAxesId }).IsUnique();

        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinadorId).OnDelete(DeleteBehavior.Restrict);

        builder
            .OwnsMany(entity => entity.StrategicActions, Configure)
            .Navigation(entity => entity.StrategicActions).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("strategicActions");

        builder
            .OwnsMany(entity => entity.StrategicProgram, Configure)
            .Navigation(entity => entity.StrategicProgram).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("strategicPrograms");

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
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicAction> builder)
    {
        builder.ToTable(STRATEGICACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicActionId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicProgram> builder)
    {
        builder.ToTable(STRATEGICPROGRAMS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.Property(entity => entity.CoordinatorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new PersonId(value));

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

        builder
            .OwnsMany(entity => entity.ProgramActions, Configure)
            .Navigation(entity => entity.ProgramActions).UsePropertyAccessMode(PropertyAccessMode.Field);

        builder
            .OwnsMany(entity => entity.ProgramIdeaProjects, Configure)
            .Navigation(entity => entity.ProgramIdeaProjects).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("programIdeaProjects");

        builder
            .OwnsMany(entity => entity.ProgramExecutionProjects, Configure)
            .Navigation(entity => entity.ProgramExecutionProjects).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("programExecutionProjects");

        builder
            .OwnsMany(entity => entity.ProgramObjetives, Configure)
            .Navigation(entity => entity.ProgramObjetives).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("programObjetives");

        builder
            .OwnsMany(entity => entity.ProgramImpacts, Configure)
            .Navigation(entity => entity.ProgramImpacts)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("programImpacts");

        builder
            .OwnsMany(entity => entity.OrganizationBridges, Configure)
            .Navigation(entity => entity.OrganizationBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("organizationBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, StrategicProgramOrganizationBridge> builder)
    {
        builder.ToTable(STRATEGICPROGRAM_ORGANIZATION_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.StrategicProgramId, bridge.StrategicLineId, bridge.StrategicAxesId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => new { bridge.StrategicProgramId, bridge.StrategicLineId, bridge.StrategicAxesId });

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new OrganizationId(value));

        builder.HasOne(entity => entity.Linked).WithMany().HasForeignKey(entity => entity.LinkedId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramAction> builder)
    {
        builder.ToTable(PROGRAMACTIONS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        //builder.Property(entity => entity.ParentId)
        //    .ValueGeneratedNever()
        //    .HasConversion(id => id!.Value.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

        //builder.HasOne(entity => entity.Parent).WithMany().HasForeignKey(entity => entity.ParentId);

        builder
            .OwnsMany(entity => entity.InterestAreaBridges, Configure)
            .Navigation(entity => entity.InterestAreaBridges)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("interestAreaBridges");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramAction, ProgramActionInterestAreaBridge> builder) 
    {
        builder.ToTable(PROGRAMACTION_INTERESTAREA_BRIDGES_TABLE_NAME);

        builder.HasKey(entity => new { entity.ProgramActionId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId, entity.LinkedId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramActionId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.ProgramActionId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramActionId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new InterestAreaId(value));

        builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramIdeaProject> builder)
    {
        builder.ToTable(PROGRAMIDEAPROJECTS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramIdeaProjectId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramExecutionProject> builder)
    {
        builder.ToTable(PROGRAMEXECUTIONPROJECTS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramExecutionProjectId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

        //builder
        //    .OwnsMany(entity => entity.ProgramObjetiveBridges, Configure)
        //    .Navigation(entity => entity.ProgramObjetiveBridges)
        //        .UsePropertyAccessMode(PropertyAccessMode.Field)
        //        .HasField("programObjetiveBridges");
    }

    //private static void Configure(OwnedNavigationBuilder<ProgramExecutionProject, ProgramExecutionProjectProgramObjetiveBridge> builder)
    //{
    //    builder.ToTable(PROGRAMEXECUTIONPROJECT_PROGRAMOBJECTIVE_BRIDGES_TABLE_NAME);

    //    builder.HasKey(entity => new { entity.ProgramExecutionProjectId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId, entity.LinkedId });

    //    builder.WithOwner().HasForeignKey(entity => new { entity.ProgramExecutionProjectId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

    //    builder.Property(entity => entity.ProgramExecutionProjectId)
    //        .ValueGeneratedNever()
    //        .HasConversion(id => id.Value, value => new ProgramExecutionProjectId(value));

    //    builder.Property(entity => entity.StrategicProgramId)
    //        .ValueGeneratedNever()
    //        .HasConversion(id => id.Value, value => new StrategicProgramId(value));

    //    builder.Property(entity => entity.StrategicLineId)
    //        .ValueGeneratedNever()
    //        .HasConversion(id => id.Value, value => new StrategicLineId(value));

    //    builder.Property(entity => entity.StrategicAxesId)
    //        .ValueGeneratedNever()
    //        .HasConversion(id => id.Value, value => new StrategicAxesId(value));

    //    builder.Property(entity => entity.LinkedId)
    //        .ValueGeneratedNever()
    //        .HasConversion(id => id.Value, value => new ProgramObjetiveId(value));

    //    builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    //}

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramObjetive> builder)
    {
        builder.ToTable(PROGRAMOBJETIVES_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramObjetiveId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
    }

    private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramImpact> builder)
    {
        builder.ToTable(PROGRAMIMPACTS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ProgramImpactId(value));

        builder.Property(entity => entity.StrategicProgramId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

        builder
            .OwnsMany(entity => entity.ImpactIndicator, Configure)
            .Navigation(entity => entity.ImpactIndicator).UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("impactIndicators");
    }

    private static void Configure(OwnedNavigationBuilder<ProgramImpact, ImpactIndicator> builder)
    {
        builder.ToTable(IMPACTINDICATORS_TABLE_NAME);

        builder.HasKey(entity => new { entity.Id, entity.ProgramImpactId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.WithOwner().HasForeignKey(entity => new { entity.ProgramImpactId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new ImpactIndicatorId(value));

        builder.Property(entity => entity.ProgramImpactId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new ProgramImpactId(value));

        builder.Property(entity => entity.StrategicProgramId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicProgramId(value));

        builder.Property(entity => entity.StrategicLineId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicLineId(value));

        builder.Property(entity => entity.StrategicAxesId)
           .ValueGeneratedNever()
           .HasConversion(id => id.Value, value => new StrategicAxesId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Alias)
            .HasMaxLength(360);

        builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProgramImpactId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

        builder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(DeleteBehavior.Restrict);
    }
}
