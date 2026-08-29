namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByObjectiveQuery(Guid ObjectiveId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;