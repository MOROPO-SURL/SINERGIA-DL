using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.UnitMeasurements.CQRS.Command.Unarchive;

public record UnitMeasurementUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;

