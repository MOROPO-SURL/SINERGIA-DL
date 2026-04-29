using MediatR;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Disable;

public record StrategicLineDisableCommand(int Id, int AxeId) : IRequest;