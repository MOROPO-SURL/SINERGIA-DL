namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.CQRS.Query.List;

public record IndicatorChangeListByProgramActionIndicatorQuery(Guid ProgramId, Guid ActionId, Guid IndicatorId) : MediatR.IRequest<DTOs.IndicatorChangeDetailDto[]>;