using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Update;

public sealed record IndicatorChangeUpdateCommand(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null) : IUpdateCommand<DateTime, DTOs.IndicatorChangeDetailDto>;