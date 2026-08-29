using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

public record StrategicProgramUpdateRequestModel(
    Guid Id,
    string Name,
    Guid LineId,
    Guid CoordinatorId,
    string Objective,
    int Priority,
    bool IsEnabled,
    Clipped.SpecificObjectiveCreateClippedRequestModel[] InSpecificObjectives,
    Clipped.SpecificObjectiveUpdateClippedRequestModel[] PatchSpecificObjectives,
    SpecificObjectiveDetailDtoModel[] OutSpecificObjectives,
    Clipped.ImpactCreateClippedRequestModel[] InImpacts,
    Clipped.ImpactUpdateClippedRequestModel[] PatchImpacts,
    ImpactDetailDtoModel[] OutImpacts,
    Clipped.ActionCreateClippedRequestModel[] InActions,
    Clipped.ActionUpdateClippedRequestModel[] PatchActions,
    ActionDetailDtoModel[] OutActions,
    OrganizationBasicDtoModel[] InOrganizations,
    OrganizationBasicDtoModel[] OutOrganizations,
    MacroprogramBasicDtoModel[] InMacroprograms,
    MacroprogramBasicDtoModel[] OutMacroprograms,
    string? Description = null);