using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Unarchive;

public record InterestAreaUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

