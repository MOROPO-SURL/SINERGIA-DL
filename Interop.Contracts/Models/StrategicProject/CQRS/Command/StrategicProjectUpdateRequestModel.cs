using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProjectUpdateRequestModel(
    Guid Id, 
    string Name, 
    Guid KindId, 
    Guid ProgramId, 
    int Priority, 
    bool IsEnabled, 
    string Objective,
    Clipped.SpecificObjectiveProjectCreateClippedRequestModel[] InSpecificObjectives,
    Clipped.SpecificObjectiveProjectUpdateClippedRequestModel[] PatchSpecificObjectives,
    SpecificObjectiveProjectDetailDtoModel[] OutSpecificObjectives,
    Clipped.IndicatorCreateClippedRequestModel[] InIndicators,
    Clipped.IndicatorUpdateClippedRequestModel[] PatchIndicators,
    IndicatorDetailDtoModel[] OutIndicators,
    MacroprogramBasicDtoModel[] InMacroprograms,
    MacroprogramBasicDtoModel[] OutMacroprograms,
    string? Description = null);