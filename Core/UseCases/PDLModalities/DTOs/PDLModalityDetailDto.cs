using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PDLModalities.DTOs;

public record PDLModalityDetailDto(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IDetailDto;
