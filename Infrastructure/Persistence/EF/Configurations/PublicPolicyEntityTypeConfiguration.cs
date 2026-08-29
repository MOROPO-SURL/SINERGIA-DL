using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.PublicPolicyAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal class PublicPolicyEntityTypeConfiguration : IEntityTypeConfiguration<PublicPolicy>
{
    private const string TABLE_NAME = "publicpolicies";

    public void Configure(EntityTypeBuilder<PublicPolicy> builder)
    {
        builder.ToTable(TABLE_NAME);

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
