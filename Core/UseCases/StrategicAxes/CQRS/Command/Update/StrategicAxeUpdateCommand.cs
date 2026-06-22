using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;

public record StrategicAxeUpdateCommand(int Id, string Name, int Priority, bool IsEnabled, Guid? CoordinatorId, string? Description = null) : IUpdateCommand<int, DTOs.StrategicAxeDetailDto>;