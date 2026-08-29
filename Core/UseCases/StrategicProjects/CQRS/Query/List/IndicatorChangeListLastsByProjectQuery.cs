namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByProjectQuery(Guid ProjectId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;