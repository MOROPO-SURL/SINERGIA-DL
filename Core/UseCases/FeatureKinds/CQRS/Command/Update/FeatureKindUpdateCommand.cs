using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Update;

public record FeatureKindUpdateCommand(Guid Id, string Name, bool IsEnabled, int Priority, string? Description = null) : IUpdateCommand<Guid, DTOs.FeatureKindDetailDto>;