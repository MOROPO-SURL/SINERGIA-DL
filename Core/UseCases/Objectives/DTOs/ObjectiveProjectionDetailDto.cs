using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveProjectionDetailDto(Guid Id, int Index, string Title, string? Description = null) : IDetailDto;