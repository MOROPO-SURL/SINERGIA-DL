namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.CQRS.Query.List;

public record IndicatorChangeListByObjectiveActionIndicatorQuery(Guid ObjectiveId, Guid ActionId, Guid IndicatorId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;