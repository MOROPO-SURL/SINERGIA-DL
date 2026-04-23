using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.CQRS.Command.Unarchive;

public record MacroprogramUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

