using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.PublicPolicy.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.CQRS.Command.Clipped;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicLine.CQRS.Command;

public record StrategicLineUpdateRequestModel(
    Guid Id, 
    int Index, 
    bool IsEnabled, 
    string Name, 
    Guid CoordinatorId,
    string Objective,
    SpecificObjectiveCreateClippedRequestModel[] InSpecificObjectives,
    SpecificObjectiveUpdateClippedRequestModel[] PathcSpecificObjectives,
    SpecificObjectiveDetailDtoModel[] OutSpecificObjective,
    PublicPolicyBasicDtoModel[] InPublicPolicies,
    PublicPolicyBasicDtoModel[] OutPublicPolicies,
    OrganizationBasicDtoModel[] InOrganizations,
    OrganizationBasicDtoModel[] OutOrganizations,
    MacroprogramBasicDtoModel[] InMacroprograms,
    MacroprogramBasicDtoModel[] OutMacroprograms,
    int? AxeId = null, 
    string? Description = null);