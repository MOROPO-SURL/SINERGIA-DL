using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.TerritorialBarriers.CQRS.Command.Unarchive;

public record TerritorialBarrierUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;