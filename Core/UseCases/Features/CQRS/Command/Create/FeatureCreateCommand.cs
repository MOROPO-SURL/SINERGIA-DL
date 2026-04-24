using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.CQRS.Command.Create;

public record FeatureCreateCommand(
    int Priority,
    Guid KindId,
    string Description) : ICreateCommand<FeatureDetailDto>;
