using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.InterestAreas.DTOs;

public record InterestAreaDetailDto(Guid Id, string Name, bool IsEnabled, string? Description = null) : IDetailDto;