using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.Ports.Repository;

public interface IFeatureQueryRepositoryPort : Common.Ports.Repository.IEntityQueryRepositoryPort<Feature, FeatureId, Guid>
{
}