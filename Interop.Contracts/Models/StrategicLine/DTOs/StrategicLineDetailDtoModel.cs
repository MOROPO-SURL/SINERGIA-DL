using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Person.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;

public record StrategicLineDetailDtoModel(
    Guid Id, 
    int Index, 
    string Name, 
    PersonBasicDtoModel Coordinator, 
    bool IsEnable, 
    string Objective,
    SpecificObjectiveDetailDtoModel[] SpecificObjectives,
    PublicPolicyBasicDtoModel[] PublicPolicies,
    OrganizationBasicDtoModel[] Organizations,
    MacroprogramBasicDtoModel[] Macroprograms,
    StrategicAxeBasicDtoModel? Axe = null, 
    string? Description = null);