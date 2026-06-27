using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Macroprogram.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.StrategicAxe.CQRS.Command;

public record StrategicAxeCreateRequestModel(
    int Id, 
    bool IsEnabled, 
    string Name,
    MacroprogramBasicDtoModel[] Macroprograms,
    Guid? CoordinatorId = null, 
    string? Description = null);