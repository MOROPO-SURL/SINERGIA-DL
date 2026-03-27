using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Entities;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations;

internal class ObjectiveEntityTypeConfiguration : IEntityTypeConfiguration<Objective>
{
    private const string OBJECTIVES_TABLE_NAME = "objectives";
    private const string CHALLANGES_TABLE_NAME = "objective_challanges";
    private const string ACTIONS_TABLE_NAME = "objective_actions";
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


        builder.Navigation(entity => entity.Projections).UsePropertyAccessMode(PropertyAccessMode.Field);
        //builder.Navigation(entity => entity.Projections).Metadata.SetField("projections");
        builder.OwnsMany(entity => entity.Projections, _builder => Configure(_builder));

        builder.Navigation(entity => entity.Challenges).UsePropertyAccessMode(PropertyAccessMode.Field);
        //builder.Navigation(entity => entity.Challenges).Metadata.SetField("challenges");
        builder.OwnsMany(entity => entity.Challenges, _builder => Configure(_builder));

        builder.Navigation(entity => entity.Actions).UsePropertyAccessMode(PropertyAccessMode.Field);
        //builder.Navigation(entity => entity.Actions).Metadata.SetField("actions");
        builder.OwnsMany(entity => entity.Actions, _builder => Configure(_builder));
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

        builder.Property(entity => entity.Title)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasIndex(entity => new { entity.Index, entity.Id, entity.ObjectiveId }).IsUnique();
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
