using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;

public record StrategicAxeDetailDto(
    int Id, 
    string Name, 
    bool IsEnabled,
    MacroprogramBasicDto[] Macroprograms,
    PersonBasicDto? Coordinator = null, 
    string? Description = null) : IDetailDto;