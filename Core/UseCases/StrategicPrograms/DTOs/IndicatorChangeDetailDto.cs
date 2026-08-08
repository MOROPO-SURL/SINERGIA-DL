using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public sealed record IndicatorChangeDetailDto(DateTime Id, Guid ProgramId, Guid ActionId, Guid IndicatorId, float Amount, string? Context = null) : IDetailDto;