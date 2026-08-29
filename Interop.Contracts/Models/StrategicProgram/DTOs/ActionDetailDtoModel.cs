namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicProgram.DTOs;

public record ActionDetailDtoModel(
    Guid Id, 
    string Title, 
    int Priority, 
    ActionIndicatorDetailDtoModel[] Indicators, 
    string? Description = null);