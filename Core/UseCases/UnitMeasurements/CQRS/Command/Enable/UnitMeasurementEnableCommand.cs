using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Enable;

public record UnitMeasurementEnableCommand(Guid Id) : IEnableCommand<Guid>;

