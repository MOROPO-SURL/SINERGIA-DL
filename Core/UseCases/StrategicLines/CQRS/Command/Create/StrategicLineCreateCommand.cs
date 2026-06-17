using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

public record StrategicLineCreateCommand(int Id, string Name, int Priority, bool IsEnabled, string Objective, Guid CoordinatorId, int? AxeId = null, string? Description = null) : MediatR.IRequest<StrategicLineDetailDto>;