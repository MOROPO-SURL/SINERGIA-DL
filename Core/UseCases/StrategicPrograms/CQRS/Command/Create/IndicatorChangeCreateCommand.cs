using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.CQRS.Command.Create;

public sealed record IndicatorChangeCreateCommand(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null) : ICreateCommand<DTOs.IndicatorChangeDetailDto>;