using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Update;

public record StrategicProjectKindUpdateCommand(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IUpdateCommand<Guid, DTOs.StrategicProjectKindDetailDto>;