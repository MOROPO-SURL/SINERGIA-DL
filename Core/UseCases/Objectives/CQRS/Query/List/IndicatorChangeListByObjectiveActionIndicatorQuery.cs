namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.List;

public record IndicatorChangeListByObjectiveActionIndicatorQuery(Guid ObjectiveId, Guid ActionId, Guid IndicatorId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;