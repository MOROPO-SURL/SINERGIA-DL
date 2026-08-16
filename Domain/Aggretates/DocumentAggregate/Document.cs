using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;

public sealed class Document : AbstractEntity<DocumentId, Guid>, IAggregateRoot<DocumentId, Guid>
{
    private Document() : base(default) { }

    public Document(DocumentId id, string name, string contentType, long length, string? description = null) : base(id)
    {
        Name = name;
        ContentType = contentType;
        Length = length;
        Description = description;
    }
    public string Name { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public long Length { get; set; }

    public string? Description { get; set; }
}
