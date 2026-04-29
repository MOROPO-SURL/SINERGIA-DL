using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveDetailDto(Guid Id, int Index, string Title, bool IsEnabled, bool IsArchived, ObjectiveChallengeDetailDto[] Challanges, ObjectiveProjectionDetailDto[] Projections, ObjectiveActionDetailDto[] Actions, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;