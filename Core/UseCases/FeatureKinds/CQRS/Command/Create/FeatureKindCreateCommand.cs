using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.FeatureKinds.CQRS.Command.Create;

public record FeatureKindCreateCommand(string Name, bool IsEnabled, int Priority, string? Description = null) : ICreateCommand<FeatureKindDetailDto>;