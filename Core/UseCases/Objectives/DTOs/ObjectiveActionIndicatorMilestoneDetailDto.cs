using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionIndicatorMilestoneDetailDto (Guid Id, DateOnly At, float Amount, string? Description = null) : IDetailDto;

