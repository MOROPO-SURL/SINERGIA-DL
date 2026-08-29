using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Classifications.CQRS.Command.Disable;

public record ClassificationDisableCommand(Guid Id) : IDisableCommand<Guid>;