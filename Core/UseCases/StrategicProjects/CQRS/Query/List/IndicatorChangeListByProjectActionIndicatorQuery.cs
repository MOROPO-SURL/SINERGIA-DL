namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

public record IndicatorChangeListByProjectActionIndicatorQuery(Guid ProjectId, Guid IndicatorId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;