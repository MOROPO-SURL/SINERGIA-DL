namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Update;

public record StrategicLineUpdateCommand(int Id, int AxeId, string Name, int Priority, bool IsEnabled, string? Description = null) : MediatR.IRequest<DTOs.StrategicLineDetailDto>;