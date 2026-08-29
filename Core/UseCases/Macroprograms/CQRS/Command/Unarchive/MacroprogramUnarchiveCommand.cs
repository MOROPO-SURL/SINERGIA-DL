using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Unarchive;

public record MacroprogramUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

