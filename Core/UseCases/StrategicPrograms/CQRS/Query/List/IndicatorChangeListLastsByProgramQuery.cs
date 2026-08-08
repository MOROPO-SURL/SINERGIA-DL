namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByProgramQuery(Guid ProgramId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;