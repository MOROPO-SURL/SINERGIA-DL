using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

public record StrategicAxeDetailDto(int Id, string Name, bool IsEnabled, string? Description = null) : IDetailDto;