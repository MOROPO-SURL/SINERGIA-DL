using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.DocumentAggregate;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Documents;

internal sealed class DocumentCommandRepositoryPortAdapter : AbstractEntityCommandRepositoryPortAdapter<Document, DocumentId, Guid>, IDocumentCommandRepositoryPort
{
    public DocumentCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}