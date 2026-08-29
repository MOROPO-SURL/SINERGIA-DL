using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Macroprogram.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeUpdateRequestModel(
    int Id, 
    bool IsEnabled, 
    string Name,
    MacroprogramBasicDtoModel[] InMacroprograms,
    MacroprogramBasicDtoModel[] OutMacroprograms,
    Guid? CoordinatorId = null, 
    string? Description = null);