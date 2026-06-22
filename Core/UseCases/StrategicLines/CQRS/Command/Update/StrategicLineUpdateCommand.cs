using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

public record StrategicLineUpdateCommand(Guid Id, int Index, string Name, int Priority, bool IsEnabled, Guid CoordinatorId, int? AxeId = null, string? Description = null) : IUpdateCommand<Guid, DTOs.StrategicLineDetailDto>;