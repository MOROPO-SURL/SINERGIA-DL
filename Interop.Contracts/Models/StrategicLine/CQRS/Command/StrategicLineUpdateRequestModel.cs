using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineUpdateRequestModel(
    Guid Id, 
    int Index, 
    bool IsEnabled, 
    string Name, 
    Guid CoordinatorId,
    string Objective,
    StrategicLineSpecificObjectiveCreateRequestModel[] InSpecificObjectives,
    StrategicLineSpecificObjectiveUpdateRequestModel[] PathcSpecificObjectives,
    StrategicLineSpecificObjectiveDetailDtoModel[] OutSpecificObjective,
    PublicPolicyBasicDtoModel[] InPublicPolicies,
    PublicPolicyBasicDtoModel[] OutPublicPolicies,
    OrganizationBasicDtoModel[] InOrganizations,
    OrganizationBasicDtoModel[] OutOrganizations,
    int? AxeId = null, 
    string? Description = null);