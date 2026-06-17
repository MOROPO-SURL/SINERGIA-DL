namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

public record StrategicLineUpdateCommand(int Id, string Name, int Priority, bool IsEnabled, int? AxeId = null, string? Description = null) : MediatR.IRequest<DTOs.StrategicLineDetailDto>;