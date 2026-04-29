using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;

public record InterestAreaBasicDto(Guid Id, string Name, bool IsEnabled, bool IsArchive, string? Description = null) : IDto;