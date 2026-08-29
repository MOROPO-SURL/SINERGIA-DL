using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveActionIndicatorMilestoneDetailDto (Guid Id, DateOnly At, float Amount, string? Description = null) : IDetailDto;

