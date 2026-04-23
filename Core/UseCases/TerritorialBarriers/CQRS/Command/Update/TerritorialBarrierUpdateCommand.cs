using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Update;

public record TerritorialBarrierUpdateCommand(Guid Id, string Title, string? Description = null) : IUpdateCommand<Guid, DTOs.TerritorialBarrierDetailDto>;