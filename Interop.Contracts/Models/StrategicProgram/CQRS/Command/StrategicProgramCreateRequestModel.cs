using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.CQRS.Command;

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