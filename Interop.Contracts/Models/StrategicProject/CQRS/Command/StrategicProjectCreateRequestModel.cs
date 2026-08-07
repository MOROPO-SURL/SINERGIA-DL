using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProject.CQRS.Command;

public record StrategicProjectCreateRequestModel(
    string Name, 
    Guid KindId, 
    Guid ProgramId, 
    int Priority, 
    bool IsEnabled, 
    string Objective,
    Clipped.SpecificObjectiveProjectCreateClippedRequestModel[] SpecificObjectives,
    Clipped.IndicatorCreateClippedRequestModel[] Indicators,
    MacroprogramBasicDtoModel[] Macroprograms,
    string? Description = null);