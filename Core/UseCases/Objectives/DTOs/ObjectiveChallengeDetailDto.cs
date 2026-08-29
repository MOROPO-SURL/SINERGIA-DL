using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveChallengeDetailDto(Guid Id, int Index, string Title, string? Description = null) : IDetailDto;