namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByProjectQuery(Guid ProjectId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;