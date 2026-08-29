using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Disable;

public record UnitMeasurementDisableCommand(Guid Id) : IDisableCommand<Guid>;

