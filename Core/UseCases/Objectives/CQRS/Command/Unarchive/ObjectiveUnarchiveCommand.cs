using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Unarchive;

public record ObjectiveUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;