using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.GEDET.CAM.Domain.Aggretates.ObjectiveAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Configurations
{
    internal class PublicPolicyEntityTypeConfiguration: IEntityTypeConfiguration<PublicPolicy>
    {
        private const string PUBLICPOLICYS_TABLE_NAME = "public_policys";

        public void Configure(EntityTypeBuilder<PublicPolicy> builder)
        {
            builder.ToTable(PUBLICPOLICYS_TABLE_NAME);

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new PublicPolicyId(value));

            builder.Property(entity => entity.Title)
                .HasMaxLength(360);

            builder.Property(entity => entity.Description)
                .HasMaxLength(2048);

            builder.HasIndex(entity => entity.Title);

        }
    }
}
