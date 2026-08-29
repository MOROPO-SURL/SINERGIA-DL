using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

public record StrategicProgramCreateRequestModel(
    string Name,
    bool IsEnabled,
    Guid LineId,
    Guid CoordinatorId,
    string Objective,
    int Priority,
    Clipped.SpecificObjectiveCreateClippedRequestModel[] SpecificObjectives,
    Clipped.ImpactCreateClippedRequestModel[] Impacts,
    Clipped.ActionCreateClippedRequestModel[] Actions,
    OrganizationBasicDtoModel[] Organizations,
    MacroprogramBasicDtoModel[] Macroprograms,
    string? Description = null);