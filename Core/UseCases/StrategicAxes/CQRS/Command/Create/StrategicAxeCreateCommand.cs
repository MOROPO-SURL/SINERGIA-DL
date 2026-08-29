using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Macroprograms.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicAxes.CQRS.Command.Create;

public record StrategicAxeCreateCommand(
    int Id, 
    string Name, 
    int Priority, 
    bool IsEnabled,
    MacroprogramBasicDto[] Macroprograms,
    Guid? CoordinatorId = null, 
    string? Description = null) : ICreateCommand<StrategicAxeDetailDto>;