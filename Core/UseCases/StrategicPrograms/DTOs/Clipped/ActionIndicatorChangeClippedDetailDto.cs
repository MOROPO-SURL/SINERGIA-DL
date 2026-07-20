using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionIndicatorChangeClippedDetailDto(DateTime Id, float Amount, string? Context = null) : IDetailDto;