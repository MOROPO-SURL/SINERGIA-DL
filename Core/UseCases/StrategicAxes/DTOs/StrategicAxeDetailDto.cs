using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

public record StrategicAxeDetailDto(
    int Id, 
    string Name, 
    bool IsEnabled,
    MacroprogramBasicDto[] Macroprograms,
    PersonBasicDto? Coordinator = null, 
    string? Description = null) : IDetailDto;