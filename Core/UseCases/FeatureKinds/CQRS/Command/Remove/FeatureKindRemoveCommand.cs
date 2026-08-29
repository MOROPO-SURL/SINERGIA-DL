using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.FeatureKinds.CQRS.Command.Remove;

public record FeatureKindRemoveCommand(Guid Id) : IRemoveCommand<Guid>;