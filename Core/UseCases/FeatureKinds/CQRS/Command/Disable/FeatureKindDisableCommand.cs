using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Disable;

public record FeatureKindDisableCommand(Guid Id) : IDisableCommand<Guid>;