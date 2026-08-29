namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

public sealed record IndicatorChangeListLastsByProgramQuery(Guid ProgramId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;