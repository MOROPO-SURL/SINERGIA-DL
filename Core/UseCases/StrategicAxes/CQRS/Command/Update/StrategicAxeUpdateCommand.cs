using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Update;

public record StrategicAxeUpdateCommand(
    int Id, 
    string Name, 
    int Priority, 
    bool IsEnabled,
    MacroprogramBasicDto[] InMacroprograms,
    MacroprogramBasicDto[] OutMacroprograms,
    Guid? CoordinatorId = null, 
    string? Description = null) : IUpdateCommand<int, DTOs.StrategicAxeDetailDto>;