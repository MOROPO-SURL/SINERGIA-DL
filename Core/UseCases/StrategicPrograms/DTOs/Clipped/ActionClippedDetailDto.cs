using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.InterestAreas.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicPrograms.DTOs.Clipped;

public record ActionClippedDetailDto(
    Guid Id,
    string Title,
    int Priority,
    InterestAreaBasicDto[] InterestAreas,
    ActionIndicatorClippedDetailDto[] Indicators,
    string? Descrtiption = null) : IDetailDto;