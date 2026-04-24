using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

public record StrategicAxeDetailDto(Guid Id, string Name, bool IsEnabled, string? Description = null) : IDetailDto;

