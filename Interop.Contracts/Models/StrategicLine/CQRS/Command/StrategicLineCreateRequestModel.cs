using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.CQRS.Command.Clipped;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineCreateRequestModel(
    int Index, 
    bool IsEnabled, 
    string Name, 
    Guid CoordinatorId, 
    string Objective,
    SpecificObjectiveCreateClippedRequestModel[] SpecificObjectives,
    PublicPolicyBasicDtoModel[] PublicPolicies,
    OrganizationBasicDtoModel[] Organizations,
    MacroprogramBasicDtoModel[] Macroprograms,
    int? AxeId = null, 
    string? Description = null);