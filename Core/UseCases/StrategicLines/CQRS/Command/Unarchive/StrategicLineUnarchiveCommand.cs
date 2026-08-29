using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.StrategicLines.CQRS.Command.Unarchive;

public record StrategicLineUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;