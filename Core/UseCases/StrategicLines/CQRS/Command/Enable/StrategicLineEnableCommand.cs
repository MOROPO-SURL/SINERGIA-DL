using MediatR;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Enable;

public record StrategicLineEnableCommand(int Id, int AxeId) : IRequest;