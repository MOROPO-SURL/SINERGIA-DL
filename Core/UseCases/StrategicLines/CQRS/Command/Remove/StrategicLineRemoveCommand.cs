using MediatR;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Remove;

public record StrategicLineRemoveCommand(int Id, int AxeId) : IRequest;