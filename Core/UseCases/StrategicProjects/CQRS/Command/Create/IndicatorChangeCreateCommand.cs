using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

public sealed record IndicatorChangeCreateCommand(DateTime Id, Guid ProjectId, Guid IndicatorId, float Amount, string? Context = null) : ICreateCommand<DTOs.IndicatorChangeDetailDto>;