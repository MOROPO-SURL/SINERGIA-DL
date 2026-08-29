using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.CQRS.Command.Archive;

public record InterestAreaArchiveCommand(Guid Id) : IArchiveCommand<Guid>;

