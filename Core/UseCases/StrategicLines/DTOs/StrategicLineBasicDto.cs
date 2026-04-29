using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineBasicDto(int Id, string Name, bool IsArchive, bool IsEnabled, StrategicAxeBasicDto StrategicAxe, string? Description = null) : IDto;