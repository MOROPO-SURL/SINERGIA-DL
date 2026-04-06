using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.TerritorialBarrierAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.TerritorialBarrierAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class TerritorialBarrierEntityTypeConfiguration: IEntityTypeConfiguration<TerritorialBarrier>
    {
        private const string TERRITORIALBARRIERS_TABLE_NAME = "territorial_barriers";

        public void Configure(EntityTypeBuilder<TerritorialBarrier> builder)
        {
            builder.ToTable(TERRITORIALBARRIERS_TABLE_NAME);

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new TerritorialBarrierId(value));

            builder.Property(entity => entity.Title)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => entity.Title);

        }
    }
}
