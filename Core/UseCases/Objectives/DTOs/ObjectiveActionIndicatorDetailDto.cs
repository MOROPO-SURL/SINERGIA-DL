using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionIndicatorDetailDto(
    Guid Id,
    string Name,
    UnitMeasurementBasicDto UnitMeasurement,
    int Priority,
    ObjectiveActionIndicatorMilestoneDetailDto[] Milestones,
    string? Alias = null) : IDetailDto;
