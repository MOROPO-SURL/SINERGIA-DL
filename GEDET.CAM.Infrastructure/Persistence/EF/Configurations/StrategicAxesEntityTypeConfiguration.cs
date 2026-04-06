using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.StrategicAxesAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class StrategicAxesEntityTypeConfiguration: IEntityTypeConfiguration<StrategicAxes>
    {
        private const string STRATEGICAXES_TABLE_NAME = "strategic_axes";
        private const string LINES_TABLE_NAME = "strategic_lines";
        private const string STRATEGICACTIONS_TABLE_NAME = "strategic_actions";
        private const string STRATEGICPROGRAMS_TABLE_NAME = "strategic_programs";

        private const string PROGRAM_ACTIONS_TABLE_NAME = "program_actions";
        private const string PROGRAM_IDEAPROYECTS_TABLE_NAME = "program_idea_proyects";
        private const string PROGRAM_EXECUTIONPROYECTS_TABLE_NAME = "program_execution_proyects";
        private const string PROGRAM_OBJETIVES_TABLE_NAME = "program_objetives";
        private const string PROGRAM_IMPACTS_TABLE_NAME = "program_impacts";

        private const string IMPACTINDICATORS_TABLE_NAME = "impact_indicators";

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


            builder.Navigation(entity => entity.Lines).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.Lines, _builder => Configure(_builder));
        }

        private static void Configure(OwnedNavigationBuilder<StrategicAxes, StrategicLine> builder)
        {
            builder.ToTable(LINES_TABLE_NAME);

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

            builder.Navigation(entity => entity.StrategicActions).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.StrategicActions, _builder => Configure(_builder));

            builder.Navigation(entity => entity.StrategicProgram).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.StrategicProgram, _builder => Configure(_builder));
        }

        private static void Configure(OwnedNavigationBuilder<StrategicLine, StrategicAction> builder)
        {
            builder.ToTable(STRATEGICACTIONS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new StrategicActionId(value));

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

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new StrategicProgramId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

            builder.Navigation(entity => entity.ProgramActions).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ProgramActions, _builder => Configure(_builder));

            builder.Navigation(entity => entity.ProgramIdeaProyect).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ProgramIdeaProyect, _builder => Configure(_builder));

            builder.Navigation(entity => entity.ProgramExecutionProyect).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ProgramExecutionProyect, _builder => Configure(_builder));

            builder.Navigation(entity => entity.ProgramObjetive).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ProgramObjetive, _builder => Configure(_builder));

            builder.Navigation(entity => entity.ProgramImpact).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ProgramImpact, _builder => Configure(_builder));
        }

        private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramAction> builder)
        {
            builder.ToTable(PROGRAM_ACTIONS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ProgramActionId(value));

            builder.Property(entity => entity.Title)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

            builder.HasOne(entity => entity.Parent).WithMany().HasForeignKey(entity => entity.ParentId); 
        }

        private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramIdeaProyect> builder)
        {
            builder.ToTable(PROGRAM_IDEAPROYECTS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ProgramIdeaProyectId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
        }

        private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramExecutionProyect> builder)
        {
            builder.ToTable(PROGRAM_EXECUTIONPROYECTS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ProgramExecutionProyectId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
        }

        private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramObjetive> builder)
        {
            builder.ToTable(PROGRAM_OBJETIVES_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ProgramObjetiveId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Index, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();
        }

        private static void Configure(OwnedNavigationBuilder<StrategicProgram, ProgramImpact> builder)
        {
            builder.ToTable(PROGRAM_IMPACTS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ProgramImpactId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => new { entity.Name, entity.Id, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

            builder.Navigation(entity => entity.ImpactIndicator).UsePropertyAccessMode(PropertyAccessMode.Field);
            //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
            builder.OwnsMany(entity => entity.ImpactIndicator, _builder => Configure(_builder));
        }

        private static void Configure(OwnedNavigationBuilder<ProgramImpact, ImpactIndicator> builder)
        {
            builder.ToTable(IMPACTINDICATORS_TABLE_NAME);

            builder.HasKey(entity => new { entity.Id, entity.ProgramImpactId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId });

            builder.WithOwner().HasForeignKey(entity => entity.ProgramImpactId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicProgramId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicLineId);

            builder.WithOwner().HasForeignKey(entity => entity.StrategicAxesId);


            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ImpactIndicatorId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(360);

            builder.Property(entity => entity.Alias)
                .HasMaxLength(360);

            builder.HasIndex(entity => new { entity.Name, entity.Id, entity.ProgramImpactId, entity.StrategicProgramId, entity.StrategicLineId, entity.StrategicAxesId }).IsUnique();

            builder.HasOne(entity => entity.UnitMeasurement).WithMany().HasForeignKey(entity => entity.UnitMeasurementId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
