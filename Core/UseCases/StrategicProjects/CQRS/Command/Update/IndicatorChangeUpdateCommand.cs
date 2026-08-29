using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

public sealed record IndicatorChangeUpdateCommand(DateTime Id, Guid ProjectId, Guid IndicatorId, float Amount, string? Context = null) : IUpdateCommand<DateTime, DTOs.IndicatorChangeDetailDto>;