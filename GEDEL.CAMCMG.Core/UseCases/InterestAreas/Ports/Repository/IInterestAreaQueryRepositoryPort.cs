using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.InterestAreaAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.Ports.Repository;

public interface IInterestAreaQueryRepositoryPort: IEntityQueryRepositoryPort<InterestArea, InterestAreaId, Guid>
{
}
