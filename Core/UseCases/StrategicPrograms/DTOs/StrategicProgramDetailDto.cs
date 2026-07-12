using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicPrograms.DTOs;

public record StrategicProgramDetailDto(
    Guid Id, 
    string Name, 
    StrategicLineBasicDto Line, 
    PersonBasicDto Coordinator, 
    bool IsEnabled, 
    int Priority, 
    string Objective,
    OrganizationBasicDto[] Organizations,
    MacroprogramBasicDto[] Macroprograms,
    string? Description = null) : IDetailDto;