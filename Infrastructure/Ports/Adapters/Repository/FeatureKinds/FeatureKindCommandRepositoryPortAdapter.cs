using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.Ports.Repository;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.FeatureKindAggregate.Values;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Adapters.Repository.FeatureKinds;

internal sealed class FeatureKindCommandRepositoryPortAdapter :
    AbstractEntityCommandRepositoryPortAdapter<FeatureKind, FeatureKindId, Guid>,
    IFeatureKindCommandRepositoryPort
{
    public FeatureKindCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}