using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.FeatureKindAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.Ports.Repository;

public interface IFeatureKindCommandRepositoryPort : IEntityCommandRepositoryPort<FeatureKind, FeatureKindId, Guid>
{
}
