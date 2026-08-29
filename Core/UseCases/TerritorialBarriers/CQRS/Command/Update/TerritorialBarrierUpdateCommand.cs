using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;

public record TerritorialBarrierUpdateCommand(Guid Id, string Title, string? Description = null) : IUpdateCommand<Guid, DTOs.TerritorialBarrierDetailDto>;