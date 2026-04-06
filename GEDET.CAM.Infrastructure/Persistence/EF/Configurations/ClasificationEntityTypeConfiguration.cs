using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class ClasificationEntityTypeConfiguration: IEntityTypeConfiguration<Clasification>
    {
        private const string CLASIFICATIONS_TABLE_NAME = "clasifications";

        public void Configure(EntityTypeBuilder<Clasification> builder)
        {
            builder.ToTable(CLASIFICATIONS_TABLE_NAME);

            builder.HasKey(t => t.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new ClasificationId(value));

            builder.Property(entity => entity.Name)
                .HasMaxLength(120);

            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(entity => entity.Description)
            .HasMaxLength(2048);
        }

    }
}


