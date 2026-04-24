using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Features.CQRS.Command.Update;

public record FeatureUpdateCommand(
    Guid Id,
    int Priority,
    Guid KindId,
    string Description) : IUpdateCommand<Guid, FeatureDetailDto>;
