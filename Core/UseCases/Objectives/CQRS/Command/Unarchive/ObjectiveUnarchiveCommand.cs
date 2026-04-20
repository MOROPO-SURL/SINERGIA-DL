using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Command.Unarchive;

public record ObjectiveUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;