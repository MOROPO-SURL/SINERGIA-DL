using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

public record StrategicLineCreateCommand(Guid Id, int Index, string Name, int Priority, bool IsEnabled, string Objective, Guid CoordinatorId, int? AxeId = null, string? Description = null) : ICreateCommand<StrategicLineDetailDto>;