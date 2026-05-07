using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Create;

public record StrategicProjectCreateCommand(string Name, int Priority, bool IsEnabled, Guid KindId, Guid ProgramId, string? Description = null) : ICreateCommand<StrategicProjectDetailDto>;