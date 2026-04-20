using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Ports.Repository;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.MacroprogramAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.Ports.Repository;

public interface IMacroprogramQueryRepositoryPort: IEntityQueryRepositoryPort<Macroprogram, MacroprogramId, Guid>
{
}
