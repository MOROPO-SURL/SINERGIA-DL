using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.CQRS.Command.Archive;

public record MacroprogramArchiveCommand(Guid Id) : IArchiveCommand<Guid>;

