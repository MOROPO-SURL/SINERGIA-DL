using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.MacroprogramAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicAxeAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.StrategicLineAggregate.Bridges;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class StrategicAxeEntityTypeConfiguration : IEntityTypeConfiguration<StrategicAxe>
{
    private const string ROOT_TABLE_NAME = "strategicaxes";
    private const string STRATEGICAXE_MACROPROGRAM_BRIDGES_TABLE_NAME = "strategicaxe_macroprogram_bridges";

    public void Configure(EntityTypeBuilder<StrategicAxe> builder)
    {
        builder.ToTable(ROOT_TABLE_NAME);

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxeId(value));

        builder.Property(entity => entity.Name)
            .HasMaxLength(360);

        builder.Property(entity => entity.Description)
            .HasMaxLength(2048);

        builder.HasOne(entity => entity.Coordinator).WithMany().HasForeignKey(entity => entity.CoordinatorId).OnDelete(DeleteBehavior.SetNull);

        builder
            .OwnsMany(entity => entity.MacroprogramBridges, Configure)
            .Navigation(entity => entity.MacroprogramBridges)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasField("macroprogramBridges");
    }

    private static void Configure(OwnedNavigationBuilder<StrategicAxe, StrategicAxeMacroprogramBridge> builder)
    {
        builder.ToTable(STRATEGICAXE_MACROPROGRAM_BRIDGES_TABLE_NAME);

        builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

        builder.WithOwner().HasForeignKey(bridge => bridge.MainId);

        builder.Property(bridge => bridge.MainId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new StrategicAxeId(value));

        builder.Property(bridge => bridge.LinkedId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MacroprogramId(value));
    }
}
