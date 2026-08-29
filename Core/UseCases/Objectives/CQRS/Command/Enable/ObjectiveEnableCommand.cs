using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Command.Enable;

public record ObjectiveEnableCommand(Guid Id) : IEnableCommand<Guid>;