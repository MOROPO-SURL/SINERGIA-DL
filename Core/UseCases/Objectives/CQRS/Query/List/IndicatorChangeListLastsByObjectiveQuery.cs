namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByObjectiveQuery(Guid ObjectiveId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;