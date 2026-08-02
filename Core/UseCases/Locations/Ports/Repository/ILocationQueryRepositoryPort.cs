using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.LocationAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Locations.Ports.Repository;

public interface ILocationQueryRepositoryPort : IEntityQueryRepositoryPort<Location, LocationId, Guid>
{
}
