namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.CQRS.Query.Detail;

public record StrategicLineDetailQuery(int Id, int AxeId) : MediatR.IRequest<DTOs.StrategicLineDetailDto>;