using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.StrategicProjects.CQRS.Command.Update;

public record StrategicProjectUpdateCommand(Guid Id, string Name, int Priority, bool IsEnabled, string? Description = null) : IUpdateCommand<Guid, DTOs.StrategicProjectDetailDto>;