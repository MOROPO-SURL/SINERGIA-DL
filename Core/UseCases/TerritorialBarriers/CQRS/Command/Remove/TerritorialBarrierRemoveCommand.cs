using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Remove;

public record TerritorialBarrierRemoveCommand(Guid Id) : IRemoveCommand<Guid>;