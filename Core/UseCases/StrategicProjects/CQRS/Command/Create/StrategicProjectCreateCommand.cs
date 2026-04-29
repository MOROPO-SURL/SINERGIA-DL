using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

public record StrategicProjectCreateCommand(string Name, int Priority, bool IsEnabled, int LineId, int AxeId, Guid CoordinatorId, string? Description = null) : ICreateCommand<StrategicProjectDetailDto>;