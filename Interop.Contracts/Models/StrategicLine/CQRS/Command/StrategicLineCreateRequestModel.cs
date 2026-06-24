using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineCreateRequestModel(
    int Index, 
    bool IsEnabled, 
    string Name, 
    Guid CoordinatorId, 
    string Objective,
    StrategicLineSpecificObjectiveCreateRequestModel[] SpecificObjectives,
    PublicPolicyBasicDtoModel[] PublicPolicies,
    OrganizationBasicDtoModel[] Organizations,
    int? AxeId = null, 
    string? Description = null);