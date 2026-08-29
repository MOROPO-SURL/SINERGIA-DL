using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Features.CQRS.Command.Update;

public record FeatureUpdateCommand(
    Guid Id,
    int Priority,
    Guid KindId,
    string Description) : IUpdateCommand<Guid, FeatureDetailDto>;
