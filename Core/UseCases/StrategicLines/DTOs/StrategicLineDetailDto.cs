using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Persons.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.PublicPolicies.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.DTOs;

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