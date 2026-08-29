using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.ClassificationAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.Classifications;

internal sealed class ClassificationQueryRepositoryPortAdapter : AbstractEntityQueryRepositoryPortAdapter<Classification, ClassificationId, Guid>, IClassificationQueryRepositoryPort
{
    public ClassificationQueryRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}