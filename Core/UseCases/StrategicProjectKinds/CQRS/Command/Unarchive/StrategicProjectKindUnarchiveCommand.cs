using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicProjectKinds.CQRS.Command.Unarchive;

public record StrategicProjectKindUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;