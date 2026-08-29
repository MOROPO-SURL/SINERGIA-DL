using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveDetailDto(Guid Id, int Index, string Title, bool IsEnabled, bool IsArchived, ObjectiveChallengeDetailDto[] Challanges, ObjectiveProjectionDetailDto[] Projections, ObjectiveActionDetailDto[] Actions, DateTime CreatedAt, DateTime? UpdatedAt = null, string? Description = null) : IDetailDto;