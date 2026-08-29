using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;

public record TerritorialBarrierUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;