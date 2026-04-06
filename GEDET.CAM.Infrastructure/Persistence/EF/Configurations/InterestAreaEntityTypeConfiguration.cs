using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class InterestAreaEntityTypeConfiguration: IEntityTypeConfiguration<InterestArea>
    {
        private const string INTERESTAREAS_TABLE_NAME = "interestareas";

        public void Configure(EntityTypeBuilder<InterestArea> builder)
        {
            builder.ToTable(INTERESTAREAS_TABLE_NAME);

            builder.HasKey(t => t.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new InterestAreaId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(120);

            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(entity => entity.Description)
            .HasMaxLength(2048);
        }
    }
}
