using MediatR;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Command.Unarchive;

public record StrategicLineUnarchiveCommand(int Id, int AxeId) : IRequest;