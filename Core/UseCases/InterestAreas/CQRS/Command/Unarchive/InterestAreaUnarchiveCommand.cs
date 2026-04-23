using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.CQRS.Command.Unarchive;

public record InterestAreaUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

