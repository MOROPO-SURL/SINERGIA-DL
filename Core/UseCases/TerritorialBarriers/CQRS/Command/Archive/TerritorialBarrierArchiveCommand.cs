using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Archive;

public record TerritorialBarrierArchiveCommand(Guid Id) : IArchiveCommand<Guid>;