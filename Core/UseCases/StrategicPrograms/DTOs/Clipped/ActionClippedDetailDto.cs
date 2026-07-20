using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionClippedDetailDto(
    Guid Id,
    string Title,
    int Priority,
    InterestAreaBasicDto[] InterestAreas,
    ActionIndicatorClippedDetailDto[] Indicators,
    string? Descrtiption = null) : IDetailDto;