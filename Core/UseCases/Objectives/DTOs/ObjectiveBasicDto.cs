using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Objectives.DTOs;

public record ObjectiveBasicDto(Guid Id, int Index, string Title, bool IsEnabled, bool IsArchived, string? Description = null) : IDto;