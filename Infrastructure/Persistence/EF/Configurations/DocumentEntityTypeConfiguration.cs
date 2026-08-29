using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Configurations;

internal sealed class DocumentEntityTypeConfiguration : IEntityTypeConfiguration<Document>
{
    private const string TABLE_NAME = "documents";

    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable(TABLE_NAME);

        builder.Property(entity => entity.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new Domain.Aggretates.DocumentAggregate.Values.DocumentId(value));

        builder.Property(entity => entity.Name)
            .IsRequired()
            .HasMaxLength(240);

        builder.Property(entity => entity.ContentType)
            .IsRequired()
            .HasMaxLength(180);

        builder.Property(entity => entity.Description)
            .HasMaxLength(1024);

        builder.HasKey(entity => entity.Id);
    }
}
