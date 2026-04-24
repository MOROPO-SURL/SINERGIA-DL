using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate.Values;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Repositories.Abstractions;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Adapters.Repository.Features;

internal sealed class FeatureCommandRepositoryPortAdapter :
    AbstractEntityCommandRepositoryPortAdapter<Feature, FeatureId, Guid>,
    IFeatureCommandRepositoryPort
{
    public FeatureCommandRepositoryPortAdapter(DefaultDbContext dbContext) : base(dbContext)
    {
    }
}