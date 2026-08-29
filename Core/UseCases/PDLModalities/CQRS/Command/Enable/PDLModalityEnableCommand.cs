using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PDLModalities.CQRS.Command.Enable;

public record PDLModalityEnableCommand(Guid Id) : IEnableCommand<Guid>;