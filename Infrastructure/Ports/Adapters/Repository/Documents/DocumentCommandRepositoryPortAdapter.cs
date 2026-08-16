using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Documents;

internal sealed class DocumentCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Document, DocumentId, Guid>, IDocumentCommandRepositoryPort
{
    public DocumentCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}