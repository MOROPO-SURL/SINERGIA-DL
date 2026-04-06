using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ClasificationAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.MacroprogramsAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.MacroprogramsAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class MacroprogramsEntityTypeConfiguration: IEntityTypeConfiguration<Macroprograms>
    {
        private const string MACROPROGRAMS_TABLE_NAME = "macroprograms";

        public void Configure(EntityTypeBuilder<Macroprograms> builder)
        {
            builder.ToTable(MACROPROGRAMS_TABLE_NAME);

            builder.HasKey(t => t.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new MacroprogramsId(value));

            builder.Property(entity => entity.Title)
            .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => entity.Index).IsUnique();
        }
    }
}
