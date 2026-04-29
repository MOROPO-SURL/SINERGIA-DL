using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Create;

public record StrategicLineCreateCommand(int Id, int AxeId, string Name, int Priority, bool IsEnabled, Guid CordinatorId, string? Description = null) : MediatR.IRequest<StrategicLineDetailDto>;