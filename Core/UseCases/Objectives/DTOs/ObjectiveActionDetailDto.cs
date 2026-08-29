using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionDetailDto(
    Guid Id, 
    int Index, 
    string Title,
    ObjectiveActionIndicatorDetailDto[] Indicators,
    string? Description = null) : IDetailDto;