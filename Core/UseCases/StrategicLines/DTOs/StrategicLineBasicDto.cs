using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineBasicDto(
    Guid Id, 
    int Index, 
    string Name, 
    bool IsArchive, 
    bool IsEnabled, 
    StrategicAxeBasicDto? Axe = null, 
    string? Description = null) : IDto;