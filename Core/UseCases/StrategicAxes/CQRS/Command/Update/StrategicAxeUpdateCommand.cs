using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Macroprograms.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;

public record StrategicAxeUpdateCommand(
    int Id, 
    string Name, 
    int Priority, 
    bool IsEnabled,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    Guid? CoordinatorId = null, 
    string? Description = null) : IUpdateCommand<int, DTOs.StrategicAxeDetailDto>;