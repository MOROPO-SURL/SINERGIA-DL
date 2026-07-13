using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicLines.DTOs;

public record StrategicLineDetailDto(
    Guid Id, 
    int Index, 
    string Name, 
    PersonBasicDto Coordinator, 
    bool IsEnabled, 
    bool IsArchive, 
    string Objective,
    StrategicLineSpecificObjectiveDetailDto[] SpecificObjectives,
    PublicPolicyBasicDto[] PublicPolicies,
    OrganizationBasicDto[] Organizations,
    MacroprogramBasicDto[] Macroprograms,
    StrategicAxeBasicDto? Axe = null, 
    string? Description = null) : IDetailDto;