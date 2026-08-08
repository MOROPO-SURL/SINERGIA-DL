namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record ActionDetailDtoModel(
    Guid Id, 
    string Title, 
    int Priority, 
    ActionIndicatorDetailDtoModel[] Indicators, 
    string? Description = null);