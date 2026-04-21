using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveDetailDto(Guid Id, int Index, string Title, ObjectiveChallengeDetailDto[] Challanges, ObjectiveProjectionDetailDto[] Projections, ObjectiveActionDetailDto[] Actions, string? Description = null) : IDetailDto;