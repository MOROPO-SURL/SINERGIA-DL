using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineBasicDto(
    Guid Id, 
    int Index, 
    string Name, 
    bool IsArchive, 
    bool IsEnabled, 
    StrategicAxeBasicDto? Axe = null, 
    string? Description = null) : IDto;