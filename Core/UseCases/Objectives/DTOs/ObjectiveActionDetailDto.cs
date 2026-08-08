using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionDetailDto(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveActionIndicatorDetailDto[] Indicators,
    string? Description = null) : IDetailDto;